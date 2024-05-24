using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
using Microsoft.Extensions.Logging;

namespace BudgetUpdatorUI;

public partial class MenuForm : Form
{
    private ILogger _logger;
    public MenuForm(ILogger<MenuForm> logger)
    {
        InitializeComponent();


        _logger = logger;
        logger.LogInformation("Loading MenuForm");

        downloadCsvsLabel.Text = "";
    }

    private void Menu_Load(object sender, EventArgs e)
    {
        RefreshMenu();
    }


    private void RefreshMenu()
    {
        _logger.LogInformation("Refreshing menu.");

        if (Utilities.CsvsExist())
        {
            _logger.LogInformation("CSVs detected.");

            updateBudgetButton.Enabled = true;
            updateBudgetLabel.Text = "CSVs detected.";
        }
        else
        {
            _logger.LogInformation("No CSVs detected.");

            updateBudgetButton.Enabled = false;
            updateBudgetLabel.Text = "";
        }
        if (Utilities.XlsxIsOpen())
        {
            _logger.LogInformation("Xlsx is open.");

            updateBudgetButton.Enabled = false;
            updateBudgetLabel.Text = "Xslx is currently open.\nClose before Updating.";
        }
        else
        {
            updateBudgetButton.Enabled = true;
            updateBudgetLabel.Text = "";
        }

        if (Utilities.PendingItemsExist())
        {
            completeItemsButton.Enabled = true;
            completeItemsLabel.Text = "$5 items to complete.";
            completeItemsLabel.ForeColor = Color.Black;
        }
        else
        {
            completeItemsButton.Enabled = false;
            completeItemsLabel.Text = "All items completed.";
            completeItemsLabel.ForeColor = Color.DarkGray;
        }

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
