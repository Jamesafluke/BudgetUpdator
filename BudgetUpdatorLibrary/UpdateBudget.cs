using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary.DataAccess;
using BudgetUpdatorLibrary.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Interfaces.Drawing.Text;
using System.ComponentModel;
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

    public void Update()
    {
        var settings = SettingsAccess.GetSettings();
        //AddDummyData();

        //xlsx
        List<BudgetItem> importedFromXlsx = ImportDataFromXlsx();
        List<BudgetItem> tempBudgetItems = DeduplicateXlsxAndDb(importedFromXlsx, BudgetAccess.GetAllBudgetItems());
        ClearAndUpdateDb(tempBudgetItems);

        //csv
        tempBudgetItems = ConvertCsvBudgetItemsToBudgetItems(ReadCsvs());
        tempBudgetItems = TrimToSelectedMonth(tempBudgetItems, settings, DateTime.Today);
        tempBudgetItems = HandleBudgetExceptions(tempBudgetItems, ItemExceptionAccess.GetItemExceptions());
        tempBudgetItems = DeduplicateCsvAndDb(tempBudgetItems, BudgetAccess.GetAllBudgetItems());
        ClearAndUpdateDb(tempBudgetItems);

        UpdateXlsxFromDb(importedFromXlsx.Count, settings);
    }

    public List<BudgetItem> TrimToSelectedMonth(List<BudgetItem> budgetItems, SettingsConfig settings, DateTime today)
    {
        _logger.LogInformation($"Trimming to selected month");
        List<BudgetItem> trimmedItems = new List<BudgetItem>();
        DateTime selectedMonth;
        if (settings.SelectPreviousMonth) { selectedMonth = today.AddMonths(-1); }
        else { selectedMonth = today; }

        foreach (var item in budgetItems)
        {
            if (item.Date.Month == selectedMonth.Month)
            {
                trimmedItems.Add(item);
            }
        }
        return trimmedItems;
    }

    public List<BudgetItem> HandleBudgetExceptions(List<BudgetItem> budgetItems, List<ItemException> exceptions)
    {
        _logger.LogInformation("Handling budget exceptions.");
        int removalExceptionsCount = 0;
        int modifyExceptionsCount = 0;

        foreach (var budgetItem in budgetItems.ToList())
        {
            foreach (var exception in exceptions.ToList())
            {
                if (budgetItem.Item == exception.Item)
                {
                    if (exception.Remove)
                    {
                        budgetItems.Remove(budgetItem);
                        removalExceptionsCount++;
                    }
                    else
                    {
                        budgetItem.Description = exception.Description;
                        budgetItem.Category = exception.Category;
                        modifyExceptionsCount++;
                    }
                }
            }
        }

        _logger.LogInformation($"Removed {removalExceptionsCount}, Modified {modifyExceptionsCount}. Total of {removalExceptionsCount + modifyExceptionsCount}.");
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

        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        try
        {
            using (var package = new ExcelPackage(Path.Combine(GlobalConfig.xlsxPath, GlobalConfig.xlsxFileName)))
            {
                var worksheet = package.Workbook.Worksheets[currentMonth.ToString("MMM")];
                budgetItems = worksheet.Cells["S7:Y199"].ToCollectionWithMappings<BudgetItem>(
                    row =>
                    {
                        var item = new BudgetItem()
                        {
                            //When it comes in from Excel, a blank cell automatically becomes 0.
                            Id = (row.GetValue<int>("Id") == 0) ? null : row.GetValue<int>("Id"),
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
        }
        catch
        {
            _logger.LogError("Importing data from xlsx failed. Make sure the worksheet exists.");
        }
        var finalBudgetItems = new List<BudgetItem>();
        foreach (var i in budgetItems)
        {
            //if(i.Id == 0) { i.Id = null; }
            if (i.Item != null)
            {
                finalBudgetItems.Add(i);
            }
        }
        _logger.LogInformation($"Imported {finalBudgetItems.Count} items from xlsx.");
        return finalBudgetItems;
    }

    public List<BudgetItem> DeduplicateXlsxAndDb(List<BudgetItem> xlsxBudgetItems, List<BudgetItem> dbBudgetItems)
    {
        _logger.LogInformation("Deduplicating xlsx and db.");
        var finalBudgetItems = dbBudgetItems;

        foreach (var xlsxBudgetItem in xlsxBudgetItems)
        {
            if (xlsxBudgetItem.Item != null && xlsxBudgetItem.Id == null)
            {
                //Item must have been manually added to the xlsx because it doesn't have an Id yet, so add it to db.
                finalBudgetItems.Add(xlsxBudgetItem);
            }
            else if (xlsxBudgetItem.Item != null && xlsxBudgetItem.Id != null)
            {
                bool matchFound = false;
                //Iterate through. The ID is expected to match and existing db item. Update it.
                foreach (var dbBudgetItem in dbBudgetItems)
                {
                    if (xlsxBudgetItem.Id == dbBudgetItem.Id)
                    {
                        //If item is in the db, update it.
                        //xlsxBudgetItem.Category = dbBudgetItem.Category;
                        //xlsxBudgetItem.Description = dbBudgetItem.Description;
                        finalBudgetItems.Remove(dbBudgetItem);
                        finalBudgetItems.Add(xlsxBudgetItem);
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
        _logger.LogInformation($"Reading {GlobalConfig.Csv1FileName}.");
        var csvItems = new List<CsvBudgetItem>();
        var finalCsvItems = new List<CsvBudgetItem>();
        try
        {
            using (var reader = new StreamReader(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv1FileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvItems = csv.GetRecords<CsvBudgetItem>().ToList();
                finalCsvItems.AddRange(csvItems);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to import {GlobalConfig.Csv1FileName}.");
            return new List<CsvBudgetItem>();
        }

        _logger.LogInformation($"$Reading {GlobalConfig.Csv2FileName}.");
        try
        {
            using (var reader = new StreamReader(Path.Combine(GlobalConfig.CsvPath, GlobalConfig.Csv2FileName)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvItems = csv.GetRecords<CsvBudgetItem>().ToList();
                finalCsvItems.AddRange(csvItems);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to import {GlobalConfig.Csv2FileName}.");
            return new List<CsvBudgetItem>();
        }
        return TrimCsvToRecent(finalCsvItems);
    }

    /// <summary>
    /// Trim down to just current month and previous month.
    /// </summary>
    /// <param name="csvBudgetItems"></param>
    /// <returns></returns>
    public List<CsvBudgetItem> TrimCsvToRecent(List<CsvBudgetItem> csvBudgetItems)
    {
        _logger.LogInformation("Trimming csv to recent items.");
        List<CsvBudgetItem> recentItems = new List<CsvBudgetItem>();
        int currentMonth = DateTime.Today.Month;
        int currentYear = DateTime.Today.Year;
        if (currentMonth == 1) { currentMonth = 12; currentYear--; }
        int lastMonth = currentMonth - 1;

        foreach (var item in csvBudgetItems)
        {
            DateTime postDate = DateTime.Parse(item.PostDate);
            if ((postDate.Month == currentMonth && postDate.Year == currentYear) ||
                (postDate.Month == lastMonth && postDate.Year == currentYear))
            {
                recentItems.Add(item);
            }
        }
        _logger.LogInformation($"Trimmed csv to {recentItems.Count} recent items.");
        return recentItems;
    }

    public List<BudgetItem> TrimBudgetItemToRecent(List<BudgetItem> budgetItems)//Do I even need this?
    {
        _logger.LogInformation("Trimming recent items.");
        List<BudgetItem> recentItems = new List<BudgetItem>();
        int currentMonth = DateTime.Today.Month;
        int currentYear = DateTime.Today.Year;
        if (currentMonth == 1) { currentMonth = 12; currentYear--; }
        int lastMonth = currentMonth - 1;

        foreach (var item in budgetItems)
        {
            if ((item.Date.Month == currentMonth && item.Date.Year == currentYear) ||
                (item.Date.Month == lastMonth && item.Date.Year == currentYear))
            {
                recentItems.Add(item);
            }
        }
        _logger.LogInformation($"Trimmed to {recentItems.Count} recent items.");
        return recentItems;
    }

    public List<BudgetItem> ConvertCsvBudgetItemsToBudgetItems(List<CsvBudgetItem> csvBudgetItems)
    {
        _logger.LogInformation("Converting csv items to budget items.");
        List<BudgetItem> budgetItems = new List<BudgetItem>();
        int checkingAddCount = 0;
        int rewardsAddCount = 0;
        foreach (var i in csvBudgetItems)
        {
            BudgetItem item = new BudgetItem
            {
                Date = DateTime.Parse(i.PostDate),
                Item = i.Description
            };

            if (i.Debit.Length > 0) { item.Amount = decimal.Parse(i.Debit); }
            else { item.Amount = decimal.Parse(i.Credit) * -1; }

            if (i.AccountNumber == GlobalConfig.checkingAccountNumber) { item.Method = "Checking"; checkingAddCount++; }
            else { item.Method = "Rewards"; rewardsAddCount++; }
            budgetItems.Add(item);
        }
        _logger.LogInformation($"{checkingAddCount} items are from Checking.");
        _logger.LogInformation($"{rewardsAddCount} items are from Rewards.");
        return budgetItems;
    }

    public List<BudgetItem> DeduplicateCsvAndDb(List<BudgetItem> csvBudget, List<BudgetItem> dbBudgetItems)
    {
        _logger.LogInformation("Deduplicating csv and db.");
        var finalBudgetItems = dbBudgetItems;



        foreach (var i in csvBudget)
        {
            bool isDuplicate = false;
            foreach (var j in dbBudgetItems.ToList()) //Something is messing with the dbBudgetItems list, so we need to make a copy. No clue why and haven't researched. 5/27.
            {
                if (i.Date == j.Date && i.Amount == j.Amount)
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

    private void UpdateXlsxFromDb(int importedFromXlsxCount, SettingsConfig settings)
    {
        _logger.LogInformation("Updating xlsx from db.");
        var budgetItems = BudgetAccess.GetAllBudgetItems();

        var month = DateTime.Today;
        string selectedMonth = month.ToString("MMM");
        if (settings.SelectPreviousMonth) { selectedMonth = DateTime.Today.AddMonths(-1).ToString("MMM"); }

        var itemsToAdd = new List<BudgetItem>();
        foreach (var i in budgetItems)
        {
            if (i.Date.Month == month.Month) { itemsToAdd.Add(i); }
        }

        int newItemsCount = importedFromXlsxCount - itemsToAdd.Count;

        _logger.LogInformation($"Updating xlsx sheet {selectedMonth} with {itemsToAdd.Count} items. {newItemsCount} net new.");

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

