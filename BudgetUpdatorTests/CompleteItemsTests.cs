using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;

namespace BudgetUpdatorTests;
[TestClass]
public class CompleteItemsTests
{
    //NOTE I don't know how to unit test this class because it's a singleton. The list IncompleteItems pulls from the database each time.
    
    //[TestMethod]
    //public void UpdateIncompleteItemsTest_TestCountByCategory()
    //{
    //    var completeItems = CompleteItems.GetCompleteItems(); 

    //    var budgetItems = new List<BudgetItem>()
    //    {
    //        new BudgetItem { Date = DateTime.Parse("5/26/2024"), Item = "F150", Category = "asdf", Method = "Checking", Amount = 50.50M },
    //        new BudgetItem { Date = DateTime.Parse("5/27/2024"), Item = "Return", Category = "asdf", Method = "Checking", Amount = -100.00M },
    //        new BudgetItem { Date = DateTime.Parse("5/27/2024"), Item = "Return", Category = "", Method = "Checking", Amount = -100.00M },
    //    };

        
    //    var settingsConfig = new SettingsConfig(2.0, false, false);


    //    completeItems.UpdateIncompleteItems(budgetItems, settingsConfig, DateTime.Parse("5/6/2024"));
    //    Assert.AreEqual(2, completeItems.GetIncompleteItemsCount());
    //}
    //[TestMethod]
    //public void UpdateIncompleteItemsTest_TestCountByMonth()
    //{

    //    var completeItems = new CompleteItems();

    //    var budgetItems = new List<BudgetItem>()
    //    {
    //        new BudgetItem { Date = DateTime.Parse("5/26/2024"), Item = "F150", Category = "", Method = "Checking", Amount = 50.50M },
    //        new BudgetItem { Date = DateTime.Parse("5/27/2024"), Item = "Return", Category = "", Method = "Checking", Amount = -100.00M },
    //        new BudgetItem { Date = DateTime.Parse("4/27/2024"), Item = "Return", Category = "", Method = "Checking", Amount = -100.00M },
    //    };

    //    var settingsConfig = new SettingsConfig(2.0, false, false);

    //    completeItems.UpdateIncompleteItems(budgetItems, settingsConfig, DateTime.Parse("5/6/2024"));
    //    Assert.AreEqual(2, completeItems.GetIncompleteItemsCount());
    //}

    //[TestMethod]
    //public void UpdateIncompleteItemsTest_TestCountWithNull()
    //{

    //    var completeItems = new CompleteItems();

    //    var budgetItems = new List<BudgetItem>()
    //    {
    //        new BudgetItem { Date = DateTime.Parse("5/26/2024"), Item = "F150", Category = null, Method = "Checking", Amount = 50.50M },
    //        new BudgetItem { Date = DateTime.Parse("5/27/2024"), Item = "Return", Category = "asdf", Method = "Checking", Amount = -100.00M },
    //        new BudgetItem { Date = DateTime.Parse("5/27/2024"), Item = "Return", Category = "", Method = "Checking", Amount = -100.00M },
    //    };

    //    var settingsConfig = new SettingsConfig(2.0, false, false);

    //    completeItems.UpdateIncompleteItems(budgetItems, settingsConfig, DateTime.Parse("5/6/2024"));
    //    Assert.AreEqual(2, completeItems.GetIncompleteItemsCount());
    //}
}
