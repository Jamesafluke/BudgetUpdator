using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetUpdatorLibrary;

namespace BudgetUpdatorTests;

using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
using BudgetUpdatorLibrary.Models;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;

[TestClass]
public class UpdateBudgetTests
{
    [TestMethod]
    public void DeduplicateXlsxAndDbTest_CategoryChange()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();

        var budgetItems = new List<BudgetItem>
        {
            new BudgetItem { Id = 1, Item = "F150", Category = "Lexi", Method = "Rewards", Amount = 50.50M }
        };

        var dbBudgetItems = new List<BudgetItem>
        {
            new BudgetItem { Id = 1, Item = "F150", Category = "James", Method = "Rewards", Amount = 50.50M }
        };

        var expected = new List<BudgetItem>
        {
            new BudgetItem { Id = 1, Item = "F150", Category = "Lexi", Method = "Rewards", Amount = 50.50M }
        };
        var updateBudget = new UpdateBudget(mockLogger.Object);


        Assert.AreEqual(expected.Count, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems).Count);
        Assert.AreEqual(expected[0].Item, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems)[0].Item);
        Assert.AreEqual(expected[0].Category, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems)[0].Category);
    }

    [TestMethod]
    public void DeduplicateXlsxAndDbTest_NewItemIsAdded()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();

        var budgetItems = new List<BudgetItem>
        {
            new BudgetItem { Id = null, Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M }
        };

        var dbBudgetItems = new List<BudgetItem>
        {
            new BudgetItem { Id = 1, Item = "F150", Category = "James", Method = "Rewards", Amount = 50.50M }
        };

        var expected = new List<BudgetItem>
        {
            new BudgetItem { Id = null, Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Id = 1, Item = "F150", Category = "James", Method = "Rewards", Amount = 50.50M },
        };

        var updateBudget = new UpdateBudget(mockLogger.Object);

        Assert.AreEqual(expected.Count, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems).Count);
    }

    [TestMethod]
    public void TrimCsvToRecentTest_RemoveItemFromTwoMonthsAgo()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();
        var csvBudgetItems = new List<CsvBudgetItem>()
        {
            new CsvBudgetItem { Description = "twoMonthsAgo", AccountNumber = "Lexi", Check = "", Debit = "50.50", PostDate = DateTime.Now.AddMonths(-2).ToString("M/dd/yyyy") },
            new CsvBudgetItem { Description = "oneMonthAgo", AccountNumber = "James", Check = "", Debit = "50.50", PostDate = DateTime.Now.AddMonths(-1).ToString("M/dd/yyyy") },
            new CsvBudgetItem { Description = "currentMonth", AccountNumber = "Mason", Check = "", Debit = "50.50", PostDate = DateTime.Now.ToString("M/dd/yyyy") },
        };

        var expected = new List<CsvBudgetItem>()
        {
            new CsvBudgetItem { Description = "oneMonthAgo", AccountNumber = "James", Check = "", Debit = "50.50", PostDate = DateTime.Now.AddMonths(-1).ToString("M/dd/yyyy") },
            new CsvBudgetItem { Description = "currentMonth", AccountNumber = "Mason", Check = "", Debit = "50.50", PostDate = DateTime.Now.ToString("M/dd/yyyy") },
        };

        var updateBudget = new UpdateBudget(mockLogger.Object);

        Assert.AreEqual(expected.Count, updateBudget.TrimCsvToRecent(csvBudgetItems).Count);
        Assert.AreEqual(expected[0].Description, updateBudget.TrimCsvToRecent(csvBudgetItems)[0].Description);
    }    //I'd like to also test the January to December situation, but I don't know how to do that with DateTime.Today. 

    [TestMethod]
    public void TrimToSelectedMonthTest_RemoveOtherMonthItems()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();
        var budgetItems = new List<BudgetItem>()
        {
            new BudgetItem { Id = null, Date = DateTime.Parse("5/5/24"), Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Id = null, Date = DateTime.Parse("6/5/24"), Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
        };

        var expected = new List<BudgetItem>()
        {
            new BudgetItem { Id = null, Date = DateTime.Parse("5/5/24"), Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
        };

        var updateBudget = new UpdateBudget(mockLogger.Object);
        var settings = new SettingsConfig(2.0, false, true);
        

        Assert.AreEqual(expected.Count, updateBudget.TrimToSelectedMonth(budgetItems, settings, DateTime.Parse("6/29/24")).Count);
    }

    [TestMethod]
    public void ConvertCsvBudgetItemsToBudgetItemsTest1()
    {

        var mockLogger = new Mock<ILogger<UpdateBudget>>();
        //750501095729 is the checking account number.

        var csvBudgetItems = new List<CsvBudgetItem>()
        {
            new CsvBudgetItem { Description = "F150", AccountNumber = "750501095729", Check = "", Debit = "50.50", Credit = "", PostDate = "5/26/2024" },
            //Account should be Checking.
            new CsvBudgetItem { Description = "LivingRoomRemodel", AccountNumber = "123", Check = "", Debit = "50.50", Credit = "", PostDate = "4/24/2024" },
            //Amount should be negative.
            new CsvBudgetItem { Description = "Return", AccountNumber = "750501095729", Check = "", Debit = "", Credit = "100.00", PostDate = "5/27/2024" },
        };
        var expected = new List<BudgetItem>()
        {
            new BudgetItem { Date = DateTime.Parse("5/26/2024"), Item = "F150", Category = "", Method = "Checking", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("4/24/2024"), Item = "LivingRoomRemodel", Category = "", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/27/2024"), Item = "Return", Category = "", Method = "Checking", Amount = -100.00M },
        };

        var updateBudget = new UpdateBudget(mockLogger.Object);



        Assert.AreEqual(expected[0].Amount, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[0].Amount);
        Assert.AreEqual(expected[1].Amount, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[1].Amount);
        Assert.AreEqual(expected[2].Amount, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[2].Amount);

        //Check that the csv's description becomes the budgetItem's item.
        Assert.AreEqual(expected[0].Item, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[0].Item);

        //Check that account becomes Checking.
        Assert.AreEqual(expected[1].Method, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[1].Method);

        //Check that account becomes Rewards.
        Assert.AreEqual(expected[0].Method, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[0].Method);

        //Check that amount become negative for a credit.
        Assert.AreEqual(expected[2].Amount, updateBudget.ConvertCsvBudgetItemsToBudgetItems(csvBudgetItems)[2].Amount);

    }

    [TestMethod]
    public void HandleBudgetExceptionsTest1()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();

        var budgetItems = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "F150",      Category = null, Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = null, Method = "Rewards", Amount = 100.00M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modely",    Category = null, Method = "Rewards", Amount = 100.00M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Model3",    Category = null, Method = "Rewards", Amount = 100.00M },
        };

        var itemExceptions = new List<ItemException>
        {
            new ItemException { Item = "F150", Remove = true },
            new ItemException { Item = "Modelx", Description = "SUV", Category = "James" },
        };


        var updateBudget = new UpdateBudget(mockLogger.Object);

        Assert.AreEqual(3, updateBudget.HandleBudgetExceptions(budgetItems, itemExceptions).Count);
        Assert.IsTrue(updateBudget.HandleBudgetExceptions(budgetItems, itemExceptions).Any(x => x.Item == "Modelx"));
    }

    //Test that duplicates aren't copied and that db is source of authority for category.
    [TestMethod]
    public void DeduplicateCsvAndDb1Test1()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();


        var csvBudget = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = 1,      Item = "F150",      Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = "Lexi", Method = "Rewards", Amount = 100.00M },
        };

        var dbBudgetItems = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = 1,      Item = "F150",      Category = "James", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = "Lexi", Method = "Rewards", Amount = 100.00M },
        };

        var expected = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = 1,      Item = "F150",      Category = "James", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = "Lexi", Method = "Rewards", Amount = 100.00M },
        };

        var updateBudget = new UpdateBudget(mockLogger.Object);

        //Make sure duplicates aren't copied.
        Assert.AreEqual(expected.Count, updateBudget.DeduplicateCsvAndDb(csvBudget, dbBudgetItems).Count);
        //Make sure db is source of authority for category.
        Assert.AreEqual(expected[0].Category, updateBudget.DeduplicateCsvAndDb(csvBudget, dbBudgetItems)[0].Category);
    }

    //Test that additional item from csv gets added successfully.
    [TestMethod]
    public void DeduplicateCsvAndDb1Test2()
    {
        var mockLogger = new Mock<ILogger<UpdateBudget>>();


        var csvBudget = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = 1,      Item = "F150",      Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = "Lexi", Method = "Rewards", Amount = 100.00M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Palisade",    Category = "Lexi", Method = "Rewards", Amount = 60.00M },
        };

        var dbBudgetItems = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = 1,      Item = "F150",      Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = "Lexi", Method = "Rewards", Amount = 100.00M },
        };

        var expected = new List<BudgetItem>
        {
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = 1,      Item = "F150",      Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Palisade",    Category = "Lexi", Method = "Rewards", Amount = 60.00M },
            new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Category = "Lexi", Method = "Rewards", Amount = 100.00M },
        };

        var updateBudget = new UpdateBudget(mockLogger.Object);

        Assert.AreEqual(expected.Count, updateBudget.DeduplicateCsvAndDb(csvBudget, dbBudgetItems).Count);
    }

    //[TestMethod()]
    //public void CalculateIncompleteItemsTest()
    //{
    //    var mockLogger = new Mock<ILogger<UpdateBudget>>();

    //    int expected = 2;

    //    var budgetItems = new List<BudgetItem>
    //    {
    //        new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "F150",      Description = "asdf", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
    //        new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Modelx",    Description = "qwer", Category = "", Method = "Rewards", Amount = 100.00M },
    //        new BudgetItem { Date = DateTime.Parse("5/25/24"), Id = null,   Item = "Palisade",  Description = "", Category = "Lexi", Method = "Rewards", Amount = 60.00M },
    //    };
    //    var updateBudget = new UpdateBudget(mockLogger.Object);

    //    Assert.AreEqual(expected, updateBudget.CalculateIncompleteItems(budgetItems));
    //}
}



