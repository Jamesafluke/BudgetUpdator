using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary.DataAccess;
using BudgetUpdatorLibrary.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Interfaces.Drawing.Text;
using System.Globalization;
using System.Runtime.ExceptionServices;

namespace BudgetUpdatorLibrary;
public class UpdateBudget
{
    private ILogger _logger;
    public UpdateBudget(ILogger logger)
    {
        _logger = logger;
    }
    public UpdateBudget()
    {
    }
    public void Update()
    {
        //AddDummyData();

        //xlsx
        ClearAndUpdateDb(DeduplicateXlsxAndDb(ImportDataFromXlsx(), BudgetAccess.GetAllBudgetItems()));

        //csv
        ClearAndUpdateDb(DeduplicateCsvAndDb(HandleBudgetExceptions(ConvertCsvBudgetItemsToBudgetItems(ReadCsvs()), ItemExceptionAccess.GetItemExceptions()), BudgetAccess.GetAllBudgetItems()));

        UpdateXlsxFromDb();
    }

    public List<BudgetItem> HandleBudgetExceptions(List<BudgetItem> budgetItems, List<ItemException> exceptions)
    {
        _logger.LogInformation("Handling budget exceptions.");
        int totalExceptions = 0;
        int removalExceptions = 0;
        int modifyExceptions = 0;
        
        foreach (var i in budgetItems.ToList())
        {
            foreach (var j in exceptions.ToList())
            {
                if (i.Item == j.Item)
                {
                    if (j.Remove)
                    {
                        budgetItems.Remove(i);
                        removalExceptions++;
                    }
                    else
                    {
                        i.Description = j.Description;
                        i.Category = j.Category;
                        modifyExceptions++;
                    }
                    totalExceptions++;
                }
            }
        }

        _logger.LogInformation($"Removed {removalExceptions} items.");
        _logger.LogInformation($"Modified {modifyExceptions} items.");
        _logger.LogInformation($"Handled {totalExceptions} total exceptions.");
        return budgetItems;
    }

    private void ClearAndUpdateDb(List<BudgetItem> budgetItems)
    {
        BudgetAccess.ClearDb();
        foreach (var i in budgetItems)
        {
            BudgetAccess.AddBudgetItem(i);
        }
    }

    private void AddDummyData()
    {
        _logger.LogInformation("Adding dummy data.");
        BudgetAccess.AddBudgetItem(budgetItem: new BudgetItem { Amount = 50.50M, Item = "F150", Method = "Rewards", Category = "James" });
        BudgetAccess.AddBudgetItem(budgetItem: new BudgetItem { Amount = 45.87M, Item = "Sewing machine", Method = "Rewards", Category = "Lexi" });
    }

    private List<BudgetItem> ImportDataFromXlsx()
    {
        _logger.LogInformation("Importing data from xlsx.");

        DateTime currentMonth = DateTime.Now;
        var settings = SettingsAccess.GetSettings();
        if (settings.SelectPreviousMonth) { currentMonth = DateTime.Now.AddMonths(-1); }

        var budgetItems = new List<BudgetItem>();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(Path.Combine(GlobalConfig.xlsxPath, GlobalConfig.xlsxFileName)))
        {
            var worksheet = package.Workbook.Worksheets[currentMonth.ToString("MMM")];
            budgetItems = worksheet.Cells["S7:Y199"].ToCollectionWithMappings<BudgetItem>(
                row =>
                {
                    var item = new BudgetItem()
                    {
                        //When it comes in from Excel, a blank cell automatically becomes 0.
                        Id = (row.GetValue<int>("Id") == 0) ? null: row.GetValue<int>("Id"),
                        Date = row.GetValue<DateTime>("Date"),
                        Item = row.GetValue<string>("Item"),
                        Description = row.GetValue<string>("Description"),
                        Method = row.GetValue<string>("Method"),
                        Category = row.GetValue<string>("Category"),
                        Amount = row.GetValue<decimal>("Amount"),
                    };

                    _logger.LogTrace($"{item.Id}, {item.Date}, {item.Item}, {item.Description}, {item.Method}, {item.Category}, {item.Amount}");
                    return item;
                },
                options => options.HeaderRow = 0);
        }
        var finalBudgetItems = new List<BudgetItem>();
        foreach (var i in budgetItems)
        {
            //if(i.Id == 0) { i.Id = null; }
            if(i.Item != null)
            {
                finalBudgetItems.Add(i);
            }
        }
        _logger.LogInformation($"Imported {finalBudgetItems.Count} items from xlsx.");
        return finalBudgetItems;
    }

    public List<BudgetItem> DeduplicateXlsxAndDb(List<BudgetItem> budgetItems, List<BudgetItem> dbBudgetItems)
    {
        _logger.LogInformation("Deduplicating xlsx and db.");
        var finalBudgetItems = dbBudgetItems;
        
        foreach (var i in budgetItems)
        {
            if (i.Item != null && i.Id == null)
            {
                //Item must be manually added to the xlsx because it doesn't have an Id yet, so add it to db.
                finalBudgetItems.Add(i);
            }
            else if (i.Item != null && i.Id != null)
            {
                bool matchFound = false;
                //Iterate through. The ID is expected to match and existing db item. Update it.
                foreach (var j in dbBudgetItems)
                {
                    if (i.Id == j.Id) {
                        //If item is in the db, update it.
                        finalBudgetItems.Remove(j);
                        finalBudgetItems.Add(i);
                        matchFound = true;
                        break;
                    }
                }
                if (!matchFound) 
                { 
                   //Throw an error because a dumb human decided to manually add an id to the xlsx.
                }
            }
        }
        return finalBudgetItems;
    }

    public List<CsvBudgetItem> ReadCsvs()
    {
        _logger.LogInformation("Reading csvs.");
        try
        {
            using (var reader = new StreamReader(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv1FileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<CsvBudgetItem> csvItems = csv.GetRecords<CsvBudgetItem>().ToList();
                return TrimToRecent(csvItems);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to import csv.");
            return new List<CsvBudgetItem>();
        }
    }

    public List<CsvBudgetItem> TrimToRecent(List<CsvBudgetItem> csvBudgetItems)
    {
        _logger.LogInformation("Trimming csv to recent items.");
        List<CsvBudgetItem> recentItems = new List<CsvBudgetItem>();
        int currentMonth = DateTime.Today.Month;
        int currentYear = DateTime.Today.Year;
        if(currentMonth == 1) { currentMonth = 12; currentYear--; }
        int lastMonth = currentMonth - 1;

        foreach (var item in csvBudgetItems)
        {
            DateTime postDate = DateTime.Parse(item.PostDate);
            if((postDate.Month == currentMonth && postDate.Year == currentYear) ||
                (postDate.Month == lastMonth && postDate.Year == currentYear))
            {
                recentItems.Add(item);
            }
        }
        _logger.LogInformation($"Trimmed csv to {recentItems.Count} recent items.");
        return recentItems;
    }

    public List<BudgetItem> ConvertCsvBudgetItemsToBudgetItems(List<CsvBudgetItem> csvBudgetItems)
    {
        _logger.LogInformation("Converting csv items to budget items.");
        List<BudgetItem> budgetItems = new List<BudgetItem>();
        foreach (var i in csvBudgetItems)
        {
            BudgetItem item = new BudgetItem
            {
                Date = DateTime.Parse(i.PostDate),
                Item = i.Description
            };

            if (i.Debit.Length > 0) { item.Amount = decimal.Parse(i.Debit); }
            else { item.Amount = decimal.Parse(i.Credit) * -1; }

            if(i.AccountNumber == GlobalConfig.checkingAccountNumber) { item.Method = "Checking"; }
            else { item.Method = "Rewards"; }
            budgetItems.Add(item);
        }
        return budgetItems;
    }

    public List<BudgetItem> DeduplicateCsvAndDb(List<BudgetItem> csvBudget, List<BudgetItem> dbBudgetItems)
    {
        _logger.LogInformation("Deduplicating csv and db.");
        var finalBudgetItems = dbBudgetItems;

        

        foreach (var i in csvBudget)
        {
            bool isDuplicate = false;
            foreach(var j in dbBudgetItems.ToList()) //Something is messing with the dbBudgetItems list, so we need to make a copy. No clue why and haven't researched. 5/27.
            {
                if(i.Date == j.Date && i.Amount == j.Amount)
                {
                    //It matches, so ignore it because we don't need to add it again.
                    isDuplicate = true;
                    break;
                }
                else
                {
                    //It doesn't match, so it's not a duplicate. 
                }
            }
            if (!isDuplicate) { finalBudgetItems.Add(i); }
        }
        return finalBudgetItems;
    }

    private void UpdateXlsxFromDb()
    {
        _logger.LogInformation("Updating xlsx from db.");
        var budgetItems = BudgetAccess.GetAllBudgetItems();
        
        var settings = SettingsAccess.GetSettings();
        var month = DateTime.Today;
        string selectedMonth = month.ToString("MMM");
        if (settings.SelectPreviousMonth) { selectedMonth = DateTime.Today.AddMonths(-1).ToString("MMM"); }

        var itemsToAdd = new List<BudgetItem>();
        foreach (var i in budgetItems)
        {
            if (i.Date.Month == month.Month){ itemsToAdd.Add(i); }
        }


        _logger.LogInformation($"Updating xlsx sheet {selectedMonth} with {budgetItems.Count} items.");

        using (var package = new ExcelPackage(Path.Combine(GlobalConfig.xlsxPath, GlobalConfig.xlsxFileName)))
        {
            foreach (var item in itemsToAdd)
            {
                var worksheet = package.Workbook.Worksheets[(selectedMonth)];
                worksheet.Cells["S8"].LoadFromCollection(itemsToAdd);
                package.Save();
            }
        }
    }
}

