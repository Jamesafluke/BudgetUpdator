namespace BudgetUpdatorUI;

partial class RemoveItemExceptionForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        idRadio = new RadioButton();
        itemRadio = new RadioButton();
        idBox = new TextBox();
        itemBox = new TextBox();
        removeButton = new Button();
        SuspendLayout();
        // 
        // idRadio
        // 
        idRadio.AutoSize = true;
        idRadio.Checked = true;
        idRadio.Location = new Point(108, 71);
        idRadio.Name = "idRadio";
        idRadio.Size = new Size(36, 19);
        idRadio.TabIndex = 0;
        idRadio.TabStop = true;
        idRadio.Text = "ID";
        idRadio.UseVisualStyleBackColor = true;
        idRadio.CheckedChanged += idRadio_CheckedChanged;
        // 
        // itemRadio
        // 
        itemRadio.AutoSize = true;
        itemRadio.ForeColor = Color.DarkGray;
        itemRadio.Location = new Point(108, 96);
        itemRadio.Name = "itemRadio";
        itemRadio.Size = new Size(49, 19);
        itemRadio.TabIndex = 2;
        itemRadio.Text = "Item";
        itemRadio.UseVisualStyleBackColor = true;
        itemRadio.CheckedChanged += itemRadio_CheckedChanged;
        // 
        // idBox
        // 
        idBox.Location = new Point(182, 70);
        idBox.Name = "idBox";
        idBox.Size = new Size(100, 23);
        idBox.TabIndex = 1;
        // 
        // itemBox
        // 
        itemBox.Enabled = false;
        itemBox.Location = new Point(182, 95);
        itemBox.Name = "itemBox";
        itemBox.Size = new Size(100, 23);
        itemBox.TabIndex = 3;
        // 
        // removeButton
        // 
        removeButton.Location = new Point(143, 250);
        removeButton.Name = "removeButton";
        removeButton.Size = new Size(75, 23);
        removeButton.TabIndex = 4;
        removeButton.Text = "Remove";
        removeButton.UseVisualStyleBackColor = true;
        removeButton.Click += removeButton_Click;
        // 
        // RemoveItemExceptionForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(352, 450);
        Controls.Add(removeButton);
        Controls.Add(itemBox);
        Controls.Add(idBox);
        Controls.Add(itemRadio);
        Controls.Add(idRadio);
        Name = "RemoveItemExceptionForm";
        Text = "RemoveItemExceptionForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RadioButton idRadio;
    private RadioButton itemRadio;
    private TextBox idBox;
    private TextBox itemBox;
    private Button removeButton;
}