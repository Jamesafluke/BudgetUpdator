using BudgetUpdatorAppLibrary;
using BudgetUpdatorLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetUpdatorUI;
public partial class CompleteItemsForm : Form
{
    static CompleteItems completeItems = CompleteItems.GetCompleteItems();
    int totalIncomplete = completeItems.GetIncompleteItemsCount();
    BudgetItem currentBudgetItem;
    public CompleteItemsForm()
    {
        InitializeComponent();
        ResetForm();
        infoLabel.Text = "";
        completeItems.Resetcounter();
    }

    private void ResetForm()
    {
        completeCountLabel.Text = $"{completeItems.GetCounter() + 1}/{totalIncomplete}";
        currentBudgetItem = completeItems.GetNextIncompleteItem();
        dateLabel.Text = currentBudgetItem.Date.ToString("MM/dd/yy");
        itemLabel.Text = currentBudgetItem.Item;
        amountLabel.Text = currentBudgetItem.Amount.ToString();
        descriptionBox.Text = "";
        categoryBox.Text = "";
        infoLabel.Text = "";
        categoryBox.Focus();
    }

    private void doneButton_Click(object sender, EventArgs e)
    {
        if (categoryBox.Text != "")
        {
            currentBudgetItem.Description = descriptionBox.Text;
            currentBudgetItem.Category = categoryBox.Text;
            completeItems.StageItem(currentBudgetItem);
            if (!completeItems.AllComplete()) { ResetForm(); }
            else { this.Close(); completeItems.WriteStagedItemsToDb(); }
        }
        else
        {
            infoLabel.Text = "Please enter a Category.";
        }
    }

    private void skipButton_Click(object sender, EventArgs e)
    {

    }

    private void splitButton_Click(object sender, EventArgs e)
    {

    }

    private void CompleteItemsForm_FormClosed(object sender, FormClosedEventArgs e)
    {

    }
}
