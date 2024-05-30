using BudgetUpdatorLibrary.DataAccess;
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
public partial class RemoveItemExceptionForm : Form
{
    public RemoveItemExceptionForm()
    {
        InitializeComponent();
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
        if (itemRadio.Checked) { ItemExceptionAccess.RemoveItemException(itemBox.Text); }
        else { ItemExceptionAccess.RemoveItemException(int.Parse(idBox.Text)); }
    }

    private void itemRadio_CheckedChanged(object sender, EventArgs e)
    {
        if(itemRadio.Checked)
        {
            idRadio.Checked = false;
            idRadio.ForeColor = Color.Black;
            itemBox.Enabled = true;
        }
    }

    private void idRadio_CheckedChanged(object sender, EventArgs e)
    {
        if (idRadio.Checked)
        {
            itemRadio.Checked = false;
            itemRadio.ForeColor = Color.Black;
            idBox.Enabled = true;
        }
    }
}




//private void modifyItemRadio_CheckedChanged(object sender, EventArgs e)
//{
//    if (modifyItemRadio.Checked)
//    {
//        removeItemRadio.Checked = false;
//        descriptionLabel.ForeColor = Color.Black;
//        categoryLabel.ForeColor = Color.Black;
//        descriptionBox.Enabled = true;
//        categoryBox.Enabled = true;
//    }
//}

//private void removeItemRadio_CheckedChanged(object sender, EventArgs e)
//{
//    if (removeItemRadio.Checked)
//    {
//        modifyItemRadio.Checked = false;
//        descriptionLabel.ForeColor = Color.DarkGray;
//        categoryLabel.ForeColor = Color.DarkGray;
//        descriptionBox.Enabled = false;
//        categoryBox.Enabled = false;
//    }
//}
