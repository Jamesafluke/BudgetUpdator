using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using BudgetUpdatorLibrary;

namespace BudgetUpdatorUI;
public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
        taxAmountLabel.Text = "";
        var settings = SettingsAccess.GetSettings();
        taxAmountBox.Text = settings.TaxAmount.ToString();
        deleteCsvsCheckBox.Checked = settings.DeleteCsvsAfterUpdating;
        selectPreviousMonthCheckBox.Checked = settings.SelectPreviousMonth;;
        selectPreviousMonthCheckBox.Text = $"Select previous month ({DateTime.Now.AddMonths(-1).ToString("MMMM")})";
    }

    private double _taxAmount;

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (ValidateSettingsForm())
        {
            SettingsConfig settingsConfig = new SettingsConfig(_taxAmount,
                                                               deleteCsvsCheckBox.Checked,
                                                               selectPreviousMonthCheckBox.Checked);
            SettingsAccess.ApplySettings(settingsConfig);
            
            this.Close();
        }
    }

    private bool ValidateSettingsForm()
    {
        if(double.TryParse(taxAmountBox.Text, out _taxAmount))
        {
            return true;
        }
        else
        {
            taxAmountLabel.ForeColor = Color.Red;
            taxAmountLabel.Text = "Enter a valid tax amount";
            return false;
        }
    }
}
