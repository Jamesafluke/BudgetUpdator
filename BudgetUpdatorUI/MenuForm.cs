using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
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
        _logger.LogInformation("Tick.");
        if (uiRefresh.AreChanges()){ RefreshMenu(); }
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

        BudgetAccess.GetAllBudgetItems();
    }



    private void completeItemsButton_Click(object sender, EventArgs e)
    {

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
            Console.WriteLine($"{i.Id} {i.Item} {i.Description} {i.Method} {i.Category} {i.Amount}");
        }
        Console.WriteLine();
    }

    private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to clear the database?", "Confirmation", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            BudgetAccess.ClearDb();
        }
        Console.WriteLine("Database cleared.\n");
    }

    private void MenuForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue.ToString() == "116")
        {
            RefreshMenu();
        }
    }


}
