using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
using BudgetUpdatorLibrary.DataAccess;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace BudgetUpdatorUI;

public partial class MenuForm : Form
{
    private ILogger _logger;
    UiRefresh uiRefresh = new UiRefresh();

    public MenuForm(ILogger<MenuForm> logger)
    {
        InitializeComponent();

        _logger = logger;
        logger.LogInformation("Loading MenuForm");

        downloadCsvsLabel.Text = "";
    }

    private void Menu_Load(object sender, EventArgs e)
    {
        timer1_Tick(sender, e);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (uiRefresh.AreChanges()) { RefreshMenu(); }
    }

    private void RefreshMenu()
    {
        _logger.LogTrace("Refreshing menu.");

        downloadCsvsLabel.Text = uiRefresh.Model.DownloadCsvsLabelText;
        updateBudgetButton.Enabled = uiRefresh.Model.UpdateBudgetButtonEnabled;
        updateBudgetLabel.Text = uiRefresh.Model.UpdateBudgetLabelText;
        completeItemsButton.Enabled = uiRefresh.Model.CompleteItemsButtonEnabled;
        completeItemsLabel.Text = uiRefresh.Model.CompleteItemsLabelText;

        lastUpdateLabel.Text = Utilities.GetLastUpdatedTimeStamp();

        dateLabel.Text = DateTime.Now.ToString("M/dd/yyyy");
    }

    private void downloadCsvsButton_Click(object sender, EventArgs e)
    {
        StartAhk startAhk = new StartAhk(_logger);
        startAhk.LaunchAHK();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        AboutForm about = new AboutForm();
        about.Show();
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        SettingsForm settings = new SettingsForm();
        settings.Show();
    }

    private void updateBudgetButton_Click(object sender, EventArgs e)
    {
        var updateBudget = new UpdateBudget(_logger);
        updateBudget.Update();

        //BudgetAccess.GetAllBudgetItems();
    }

    private void completeItemsButton_Click(object sender, EventArgs e)
    {
        var completeItemsForm = new CompleteItemsForm();
        completeItemsForm.Show();
    }

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //TODO automate this and delete this property.
        RefreshMenu();
    }

    private void listAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _logger.LogInformation("Listing all items.");
        var budgetItems = BudgetAccess.GetAllBudgetItems();
        foreach (var i in budgetItems)
        {
            _logger.LogInformation($"    {i.Id} {i.Item} {i.Description} {i.Method} {i.Category} {i.Amount}");
        }
    }

    private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to clear the database?", "Confirmation", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            BudgetAccess.ClearDb();
        }
        _logger.LogInformation("Database cleared.\n");
    }

    private void MenuForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue.ToString() == "116")
        {
            RefreshMenu();
        }
    }

    private void deleteCSVsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Utilities.CsvsExist())
        {
            var result = MessageBox.Show("Are you sure you want to delete the CSVs?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Utilities.DeleteCsvs();
            }
        }
        else
        {
            MessageBox.Show("No CSVs to delete.");
        }
    }

    private void addExceptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var exceptionForm = new ExceptionForm();
        exceptionForm.Show();
    }

    private void listExceptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _logger.LogInformation("Listing all exceptions.");
        foreach (var i in ItemExceptionAccess.GetItemExceptions())
        {
            _logger.LogInformation($"    {i.Id} {i.Item} {i.Description} {i.Category} {i.Remove}");
        }
    }

    private void removeExceptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var removeItemExceptionForm = new RemoveItemExceptionForm();
        removeItemExceptionForm.Show();
    }
}
