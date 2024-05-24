using System.Text.Json;

namespace BudgetUpdatorLibrary;

public class SettingsConfig
{
    public int Id { get; set; }
    public double TaxAmount { get; set; }
    public bool DeleteCsvsAfterUpdating { get; set; }
    public bool SelectPreviousMonth { get; set; }

    public SettingsConfig(double taxAmount, bool deleteCsvsAfterUpdating, bool selectPreviousMonth)
    {
        TaxAmount = taxAmount;
        DeleteCsvsAfterUpdating = deleteCsvsAfterUpdating;
        SelectPreviousMonth = selectPreviousMonth;
    }

    public void WriteDb()
    {
        using (BudgetDbContext db = new BudgetDbContext())
        {
            db.Settings.Add(this);
        }
    }
}