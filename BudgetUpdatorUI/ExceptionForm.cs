using BudgetUpdatorLibrary.DataAccess;
using BudgetUpdatorLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetUpdatorUI;
public partial class ExceptionForm : Form
{
    public ExceptionForm()
    {
        InitializeComponent();
    }

    private void modifyItemRadio_CheckedChanged(object sender, EventArgs e)
    {
        if (modifyItemRadio.Checked)
        {
            removeItemRadio.Checked = false;
            descriptionLabel.ForeColor = Color.Black;
            categoryLabel.ForeColor = Color.Black;
            descriptionBox.Enabled = true;
            categoryBox.Enabled = true;
        }
    }

    private void removeItemRadio_CheckedChanged(object sender, EventArgs e)
    {
        if (removeItemRadio.Checked)
        {
            modifyItemRadio.Checked = false;
            descriptionLabel.ForeColor = Color.DarkGray;
            categoryLabel.ForeColor = Color.DarkGray;
            descriptionBox.Enabled = false;
            categoryBox.Enabled = false;
        }
    }

    private void createButton_Click(object sender, EventArgs e)
    {
        var itemException = new ItemException();

        if (removeItemRadio.Checked)
        {
            itemException.Item = itemBox.Text;
            itemException.Remove = false;
        }
        else
        {
            itemException.Item = itemBox.Text;
            itemException.Description = descriptionBox.Text;
            itemException.Category = categoryBox.Text;
        }

        ItemExceptionAccess.AddItemException(itemException);

        this.Close();
    }
}
