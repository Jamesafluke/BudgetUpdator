using BudgetUpdatorLibrary;
using OfficeOpenXml.Utils;
using System.Drawing;

namespace BudgetUpdatorLibrary;
public class UiRefresh
{
    public UiRefreshModel Model = new UiRefreshModel();
    private UiRefreshModel _tempModel = new UiRefreshModel();
    CompleteItems completeItems = CompleteItems.GetCompleteItems();

    public bool AreChanges()
    {
        UpdateModel();

        if (!AreEqual(_tempModel, Model)) //If there's a difference, there's a need to refresh.
        {
            Model.DownloadCsvsLabelText = _tempModel.DownloadCsvsLabelText;
            Model.UpdateBudgetButtonEnabled = _tempModel.UpdateBudgetButtonEnabled;
            Model.UpdateBudgetLabelText = _tempModel.UpdateBudgetLabelText;
            Model.CompleteItemsButtonEnabled = _tempModel.CompleteItemsButtonEnabled;
            Model.CompleteItemsLabelText = _tempModel.CompleteItemsLabelText;

            return true;
        }
        return false; 
    }

    public bool AreEqual(UiRefreshModel tempModel, UiRefreshModel model)
    {
        if (tempModel.UpdateBudgetButtonEnabled == model.UpdateBudgetButtonEnabled
            && tempModel.CompleteItemsButtonEnabled == model.CompleteItemsButtonEnabled
            && tempModel.DownloadCsvsLabelText == model.DownloadCsvsLabelText
            && tempModel.UpdateBudgetLabelText == model.UpdateBudgetLabelText
            && tempModel.CompleteItemsLabelText == model.CompleteItemsLabelText
            && tempModel.LastUpdatedLabelText == model.LastUpdatedLabelText)
        {
            return true;
        }
        else { return false; }
    }

    public void UpdateModel()
    {
        if (Utilities.CsvsExist()) { _tempModel.DownloadCsvsLabelText = ""; }
        else { _tempModel.DownloadCsvsLabelText = "CSVs not found."; }

        if (Utilities.XlsxIsClosed() && Utilities.CsvsExist()) { _tempModel.UpdateBudgetButtonEnabled = true; }
        else { _tempModel.UpdateBudgetButtonEnabled = false; }

        if (Utilities.XlsxIsClosed()) { _tempModel.UpdateBudgetLabelText = ""; }
        else { _tempModel.UpdateBudgetLabelText = "Xlsx is open."; }

        if (completeItems.IncompleteItemsExist()) { _tempModel.CompleteItemsButtonEnabled = true; }
        else { _tempModel.CompleteItemsButtonEnabled = false; }

        if (completeItems.IncompleteItemsExist()) { _tempModel.CompleteItemsLabelText = "Pending Items Exist."; }
        else { _tempModel.CompleteItemsLabelText = ""; }
    }
}

public class UiRefreshModel
{
    public bool UpdateBudgetButtonEnabled { get; set; } = true;
    public bool CompleteItemsButtonEnabled { get; set; } = true;
    public string? DownloadCsvsLabelText { get; set; } = "";
    public string? UpdateBudgetLabelText { get; set; } = "";
    public string? CompleteItemsLabelText { get; set; } = "";
    public string? LastUpdatedLabelText { get; set; } = "";
}




