using BudgetUpdatorAppLibrary;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Interfaces.Drawing.Text;
using System.Globalization;

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
        UpdateDb(DeduplicateXlsxAndDb(ImportDataFromXlsx(), BudgetAccess.GetAllBudgetItems()));


        //csv
        //List<RawBudgetItem> csvBudgetRaw = ReadCsvs();
        //List<BudgetItem> csvBudget = ConvertRawToBudget(csvBudgetRaw);



        UpdateXlsxFromDb();
    }

    private void UpdateDb(List<BudgetItem> budgetItems)
    {
        BudgetAccess.ClearDb();
        foreach (var i in budgetItems)
        {
            BudgetAccess.AddBudgetItem(i);
        }
    }

    private void AddDummyData()
    {
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
        return finalBudgetItems;
        
    }

    public List<BudgetItem> DeduplicateXlsxAndDb(List<BudgetItem> budgetItems, List<BudgetItem> dbBudgetItems)
    {
        var finalBudgetItems = dbBudgetItems;
        
        foreach (var i in budgetItems)
        {
            if (i.Item != null && i.Id == 0)
            {
                //Item must be new because it doesn't have an Id yet, so add it.
                finalBudgetItems.Add(i);
            }
            else if (i.Item != null && i.Id != 0)
            {
                //Iterate through. If there's a match by Id to an existing item, update it.
                foreach (var j in dbBudgetItems)
                {
                    if (i.Id == j.Id) {
                        //If the item is in the db, update it.
                        finalBudgetItems.Remove(j);
                        finalBudgetItems.Add(i);
                        break;
                    };
                }
            }
            else
            {
                //The row is empty, or there's no match in the existing db. Disregard.
            }
        }
        return finalBudgetItems;
    }

    public List<RawBudgetItem> ReadCsvs()
    {
        try
        {
            using (var reader = new StreamReader(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv1FileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<RawBudgetItem> rawItems = csv.GetRecords<RawBudgetItem>().ToList();
                return TrimToRecent(rawItems);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to import csv.");
            return new List<RawBudgetItem>();
        }
    }

    private static List<RawBudgetItem> TrimToRecent(List<RawBudgetItem> rawBudgetItems)
    {
        List<RawBudgetItem> recentItems = new List<RawBudgetItem>();
        int currentMonth = DateTime.Today.Month;
        int currentYear = DateTime.Today.Year;
        int lastMonth = currentMonth - 1;
        int lastYear = currentYear - 1;

        foreach (var item in rawBudgetItems)
        {
            DateTime postDate = DateTime.Parse(item.PostDate);
            if((postDate.Month == currentMonth && postDate.Year == currentYear) ||
                (postDate.Month == lastMonth && postDate.Year == lastYear))
            {
                recentItems.Add(item);
            }
        }
        return recentItems;
    }

    private List<BudgetItem> ConvertRawToBudget(List<RawBudgetItem> rawBudgetItems)
    {
        List<BudgetItem> budgetItems = new List<BudgetItem>();
        foreach (var i in rawBudgetItems)
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
        }
        return budgetItems;
    }

    

    private void UpdateXlsxFromDb()
    {
        var budgetItems = BudgetAccess.GetAllBudgetItems();
        
        using (var package = new ExcelPackage(Path.Combine(GlobalConfig.xlsxPath, GlobalConfig.xlsxFileName)))
        {
            foreach (var item in budgetItems)
            {
                var worksheet = package.Workbook.Worksheets[DateTime.Today.ToString("MMM")];
                worksheet.Cells["S8"].LoadFromCollection(budgetItems);
                package.Save();
            }
        }
    }
}

