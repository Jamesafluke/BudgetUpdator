namespace BudgetUpdatorUI;

partial class CompleteItemsForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompleteItemsForm));
        completeCountLabel = new Label();
        itemStaticLabel = new Label();
        dateStaticLabel = new Label();
        dateLabel = new Label();
        itemLabel = new Label();
        label2 = new Label();
        amountLabel = new Label();
        label4 = new Label();
        descriptionStaticLabel = new Label();
        categoryStaticLabel = new Label();
        infoLabel = new Label();
        splitButton = new Button();
        descriptionBox = new TextBox();
        categoryBox = new TextBox();
        skipButton = new Button();
        doneButton = new Button();
        SuspendLayout();
        // 
        // completeCountLabel
        // 
        completeCountLabel.AutoSize = true;
        completeCountLabel.BackColor = Color.White;
        completeCountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        completeCountLabel.Location = new Point(95, 9);
        completeCountLabel.Margin = new Padding(4, 0, 4, 0);
        completeCountLabel.Name = "completeCountLabel";
        completeCountLabel.Size = new Size(206, 28);
        completeCountLabel.TabIndex = 0;
        completeCountLabel.Text = "completeCountLabel";
        // 
        // itemStaticLabel
        // 
        itemStaticLabel.AutoSize = true;
        itemStaticLabel.BackColor = Color.White;
        itemStaticLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        itemStaticLabel.Location = new Point(32, 9);
        itemStaticLabel.Margin = new Padding(4, 0, 4, 0);
        itemStaticLabel.Name = "itemStaticLabel";
        itemStaticLabel.Size = new Size(55, 28);
        itemStaticLabel.TabIndex = 1;
        itemStaticLabel.Text = "Item";
        // 
        // dateStaticLabel
        // 
        dateStaticLabel.AutoSize = true;
        dateStaticLabel.BackColor = Color.White;
        dateStaticLabel.Location = new Point(79, 64);
        dateStaticLabel.Margin = new Padding(4, 0, 4, 0);
        dateStaticLabel.Name = "dateStaticLabel";
        dateStaticLabel.Size = new Size(53, 28);
        dateStaticLabel.TabIndex = 2;
        dateStaticLabel.Text = "Date";
        // 
        // dateLabel
        // 
        dateLabel.AutoSize = true;
        dateLabel.BackColor = Color.White;
        dateLabel.Location = new Point(170, 64);
        dateLabel.Margin = new Padding(4, 0, 4, 0);
        dateLabel.Name = "dateLabel";
        dateLabel.Size = new Size(97, 28);
        dateLabel.TabIndex = 3;
        dateLabel.Text = "dateLabel";
        // 
        // itemLabel
        // 
        itemLabel.AutoSize = true;
        itemLabel.BackColor = Color.White;
        itemLabel.Location = new Point(170, 92);
        itemLabel.Margin = new Padding(4, 0, 4, 0);
        itemLabel.Name = "itemLabel";
        itemLabel.Size = new Size(65, 28);
        itemLabel.TabIndex = 5;
        itemLabel.Text = "label1";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = Color.White;
        label2.Location = new Point(79, 92);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(51, 28);
        label2.TabIndex = 4;
        label2.Text = "Item";
        // 
        // amountLabel
        // 
        amountLabel.AutoSize = true;
        amountLabel.BackColor = Color.White;
        amountLabel.Location = new Point(170, 120);
        amountLabel.Margin = new Padding(4, 0, 4, 0);
        amountLabel.Name = "amountLabel";
        amountLabel.Size = new Size(65, 28);
        amountLabel.TabIndex = 7;
        amountLabel.Text = "label3";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.BackColor = Color.White;
        label4.Location = new Point(79, 120);
        label4.Margin = new Padding(4, 0, 4, 0);
        label4.Name = "label4";
        label4.Size = new Size(83, 28);
        label4.TabIndex = 6;
        label4.Text = "Amount";
        // 
        // descriptionStaticLabel
        // 
        descriptionStaticLabel.AutoSize = true;
        descriptionStaticLabel.BackColor = Color.White;
        descriptionStaticLabel.Location = new Point(79, 189);
        descriptionStaticLabel.Margin = new Padding(4, 0, 4, 0);
        descriptionStaticLabel.Name = "descriptionStaticLabel";
        descriptionStaticLabel.Size = new Size(112, 28);
        descriptionStaticLabel.TabIndex = 8;
        descriptionStaticLabel.Text = "Description";
        // 
        // categoryStaticLabel
        // 
        categoryStaticLabel.AutoSize = true;
        categoryStaticLabel.BackColor = Color.White;
        categoryStaticLabel.Location = new Point(79, 238);
        categoryStaticLabel.Margin = new Padding(4, 0, 4, 0);
        categoryStaticLabel.Name = "categoryStaticLabel";
        categoryStaticLabel.Size = new Size(92, 28);
        categoryStaticLabel.TabIndex = 8;
        categoryStaticLabel.Text = "Category";
        // 
        // infoLabel
        // 
        infoLabel.AutoSize = true;
        infoLabel.BackColor = Color.White;
        infoLabel.Location = new Point(79, 305);
        infoLabel.Margin = new Padding(4, 0, 4, 0);
        infoLabel.Name = "infoLabel";
        infoLabel.Size = new Size(92, 28);
        infoLabel.TabIndex = 8;
        infoLabel.Text = "infoLabel";
        // 
        // splitButton
        // 
        splitButton.Enabled = false;
        splitButton.Location = new Point(406, 366);
        splitButton.Margin = new Padding(4);
        splitButton.Name = "splitButton";
        splitButton.Size = new Size(156, 48);
        splitButton.TabIndex = 5;
        splitButton.Text = "Spli&t";
        splitButton.UseVisualStyleBackColor = true;
        splitButton.Click += splitButton_Click;
        // 
        // descriptionBox
        // 
        descriptionBox.Location = new Point(198, 186);
        descriptionBox.Name = "descriptionBox";
        descriptionBox.Size = new Size(265, 34);
        descriptionBox.TabIndex = 0;
        // 
        // categoryBox
        // 
        categoryBox.Location = new Point(198, 235);
        categoryBox.Name = "categoryBox";
        categoryBox.Size = new Size(265, 34);
        categoryBox.TabIndex = 1;
        // 
        // skipButton
        // 
        skipButton.Enabled = false;
        skipButton.Location = new Point(242, 366);
        skipButton.Margin = new Padding(4);
        skipButton.Name = "skipButton";
        skipButton.Size = new Size(156, 48);
        skipButton.TabIndex = 9;
        skipButton.Text = "&Skip";
        skipButton.UseVisualStyleBackColor = true;
        skipButton.Click += skipButton_Click;
        // 
        // doneButton
        // 
        doneButton.Enabled = false;
        doneButton.Location = new Point(79, 366);
        doneButton.Margin = new Padding(4);
        doneButton.Name = "doneButton";
        doneButton.Size = new Size(156, 48);
        doneButton.TabIndex = 10;
        doneButton.Text = "&Done";
        doneButton.UseVisualStyleBackColor = true;
        doneButton.Click += doneButton_Click;
        // 
        // CompleteItemsForm
        // 
        AutoScaleDimensions = new SizeF(11F, 28F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(649, 446);
        Controls.Add(doneButton);
        Controls.Add(skipButton);
        Controls.Add(categoryBox);
        Controls.Add(descriptionBox);
        Controls.Add(splitButton);
        Controls.Add(infoLabel);
        Controls.Add(categoryStaticLabel);
        Controls.Add(descriptionStaticLabel);
        Controls.Add(amountLabel);
        Controls.Add(label4);
        Controls.Add(itemLabel);
        Controls.Add(label2);
        Controls.Add(dateLabel);
        Controls.Add(dateStaticLabel);
        Controls.Add(itemStaticLabel);
        Controls.Add(completeCountLabel);
        Font = new Font("Segoe UI", 12F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4, 6, 4, 6);
        Name = "CompleteItemsForm";
        Text = "Complete Items";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label completeCountLabel;
    private Label itemStaticLabel;
    private Label dateStaticLabel;
    private Label dateLabel;
    private Label itemLabel;
    private Label label2;
    private Label amountLabel;
    private Label label4;
    private Label descriptionStaticLabel;
    private Label categoryStaticLabel;
    private Label infoLabel;
    private Button splitButton;
    private TextBox descriptionBox;
    private TextBox categoryBox;
    private Button skipButton;
    private Button doneButton;
}