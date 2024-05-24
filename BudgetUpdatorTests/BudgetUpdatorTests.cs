namespace BudgetUpdatorTests;

using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

[TestClass]
public class BudgetUpdatorTests
{
    [TestMethod]
    public void DeduplicateXlsxAndDbTest1()
    {
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
        var updateBudget = new UpdateBudget();

        Assert.AreEqual(expected.Count, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems).Count);
        Assert.AreEqual(expected[0].Item, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems)[0].Item);
        Assert.AreEqual(expected[0].Category, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems)[0].Category);
    }
    [TestMethod]
    public void DeduplicateXlsxAndDbTest2()
    {
        var budgetItems = new List<BudgetItem>
        {
            new BudgetItem { Id = 0, Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M }
        };

        var dbBudgetItems = new List<BudgetItem>
        {
            new BudgetItem { Id = 1, Item = "F150", Category = "James", Method = "Rewards", Amount = 50.50M }
        };

        var expected = new List<BudgetItem>
        {
            new BudgetItem { Id = null, Item = "sewingmachine", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
            new BudgetItem { Id = 1, Item = "F150", Category = "Lexi", Method = "Rewards", Amount = 50.50M },
        };
        var updateBudget = new UpdateBudget();

        Assert.AreEqual(expected.Count, updateBudget.DeduplicateXlsxAndDb(budgetItems, dbBudgetItems).Count);
    }
}