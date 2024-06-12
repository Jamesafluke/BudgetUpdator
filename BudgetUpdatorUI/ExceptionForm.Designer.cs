namespace BudgetUpdatorUI;

partial class ExceptionForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
        createButton = new Button();
        itemBox = new TextBox();
        categoryBox = new TextBox();
        descriptionBox = new TextBox();
        removeItemRadio = new RadioButton();
        modifyItemRadio = new RadioButton();
        categoryLabel = new Label();
        descriptionLabel = new Label();
        itemLabel = new Label();
        SuspendLayout();
        // 
        // createButton
        // 
        createButton.Font = new Font("Segoe UI", 12F);
        createButton.Location = new Point(123, 341);
        createButton.Margin = new Padding(4, 5, 4, 5);
        createButton.Name = "createButton";
        createButton.Size = new Size(160, 71);
        createButton.TabIndex = 5;
        createButton.Text = "&Create";
        createButton.UseVisualStyleBackColor = true;
        createButton.Click += createButton_Click;
        // 
        // itemBox
        // 
        itemBox.Location = new Point(135, 60);
        itemBox.Name = "itemBox";
        itemBox.Size = new Size(229, 25);
        itemBox.TabIndex = 0;
        // 
        // categoryBox
        // 
        categoryBox.Enabled = false;
        categoryBox.Location = new Point(135, 251);
        categoryBox.Name = "categoryBox";
        categoryBox.Size = new Size(229, 25);
        categoryBox.TabIndex = 4;
        // 
        // descriptionBox
        // 
        descriptionBox.Enabled = false;
        descriptionBox.Location = new Point(135, 215);
        descriptionBox.Name = "descriptionBox";
        descriptionBox.Size = new Size(229, 25);
        descriptionBox.TabIndex = 3;
        // 
        // removeItemRadio
        // 
        removeItemRadio.AutoSize = true;
        removeItemRadio.Checked = true;
        removeItemRadio.Location = new Point(33, 123);
        removeItemRadio.Name = "removeItemRadio";
        removeItemRadio.Size = new Size(108, 23);
        removeItemRadio.TabIndex = 1;
        removeItemRadio.TabStop = true;
        removeItemRadio.Text = "Remove Item";
        removeItemRadio.UseVisualStyleBackColor = true;
        removeItemRadio.CheckedChanged += removeItemRadio_CheckedChanged;
        // 
        // modifyItemRadio
        // 
        modifyItemRadio.AutoSize = true;
        modifyItemRadio.Location = new Point(33, 156);
        modifyItemRadio.Name = "modifyItemRadio";
        modifyItemRadio.Size = new Size(102, 23);
        modifyItemRadio.TabIndex = 2;
        modifyItemRadio.TabStop = true;
        modifyItemRadio.Text = "Modify Item";
        modifyItemRadio.UseVisualStyleBackColor = true;
        modifyItemRadio.CheckedChanged += modifyItemRadio_CheckedChanged;
        // 
        // categoryLabel
        // 
        categoryLabel.AutoSize = true;
        categoryLabel.ForeColor = Color.DarkGray;
        categoryLabel.Location = new Point(33, 254);
        categoryLabel.Name = "categoryLabel";
        categoryLabel.Size = new Size(65, 19);
        categoryLabel.TabIndex = 28;
        categoryLabel.Text = "Category";
        // 
        // descriptionLabel
        // 
        descriptionLabel.AutoSize = true;
        descriptionLabel.ForeColor = Color.DarkGray;
        descriptionLabel.Location = new Point(33, 218);
        descriptionLabel.Name = "descriptionLabel";
        descriptionLabel.Size = new Size(78, 19);
        descriptionLabel.TabIndex = 29;
        descriptionLabel.Text = "Description";
        // 
        // itemLabel
        // 
        itemLabel.AutoSize = true;
        itemLabel.Location = new Point(33, 63);
        itemLabel.Name = "itemLabel";
        itemLabel.Size = new Size(37, 19);
        itemLabel.TabIndex = 31;
        itemLabel.Text = "Item";
        // 
        // ExceptionForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(418, 462);
        Controls.Add(itemLabel);
        Controls.Add(descriptionLabel);
        Controls.Add(categoryLabel);
        Controls.Add(modifyItemRadio);
        Controls.Add(removeItemRadio);
        Controls.Add(descriptionBox);
        Controls.Add(categoryBox);
        Controls.Add(itemBox);
        Controls.Add(createButton);
        Font = new Font("Segoe UI", 10F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "ExceptionForm";
        Text = "Create Exception";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button createButton;
    private TextBox itemBox;
    private TextBox categoryBox;
    private TextBox descriptionBox;
    private RadioButton removeItemRadio;
    private RadioButton modifyItemRadio;
    private Label categoryLabel;
    private Label descriptionLabel;
    private Label itemLabel;
}