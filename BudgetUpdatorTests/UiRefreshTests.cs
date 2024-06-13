using BudgetUpdatorLibrary;

namespace BudgetUpdatorTests;

[TestClass]
public class UiRefreshTests
{
    [TestMethod]
    //Test that they're NOT equal.
    public void AreEqualTest1()
    {
        var completeItems = new CompleteItems();
        var uiRefresh = new UiRefresh(completeItems);

        UiRefreshModel model = new UiRefreshModel();
        UiRefreshModel tempModel = new UiRefreshModel();

        tempModel.UpdateBudgetButtonEnabled = true;
        tempModel.CompleteItemsButtonEnabled = true;
        tempModel.DownloadCsvsLabelText = "CSVs not found.";
        tempModel.UpdateBudgetLabelText = "Xlsx is open.";
        tempModel.CompleteItemsLabelText = "Pending Items Exist.";
        tempModel.LastUpdatedLabelText = "Never";

        model.UpdateBudgetButtonEnabled = true;
        //Difference:
        model.CompleteItemsButtonEnabled = false;
        model.DownloadCsvsLabelText = "CSVs not found.";
        model.UpdateBudgetLabelText = "Xlsx is open.";
        model.CompleteItemsLabelText = "Pending Items Exist.";
        model.LastUpdatedLabelText = "Never";

        Assert.IsFalse(uiRefresh.AreEqual(tempModel, model));
    }

    [TestMethod]
    //Test that they're equal.
    public void AreEqualTest2()
    {
        var completeItems = new CompleteItems();
        var uiRefresh = new UiRefresh(completeItems);

        UiRefreshModel model = new UiRefreshModel();
        UiRefreshModel tempModel = new UiRefreshModel();

        tempModel.UpdateBudgetButtonEnabled = true;
        tempModel.CompleteItemsButtonEnabled = true;
        tempModel.DownloadCsvsLabelText = "CSVs not found.";
        tempModel.UpdateBudgetLabelText = "Xlsx is open.";
        tempModel.CompleteItemsLabelText = "Pending Items Exist.";
        tempModel.LastUpdatedLabelText = "Never";

        model.UpdateBudgetButtonEnabled = true;
        model.CompleteItemsButtonEnabled = true;
        model.DownloadCsvsLabelText = "CSVs not found.";
        model.UpdateBudgetLabelText = "Xlsx is open.";
        model.CompleteItemsLabelText = "Pending Items Exist.";
        model.LastUpdatedLabelText = "Never";

        Assert.IsTrue(uiRefresh.AreEqual(tempModel, model));
    }
}
