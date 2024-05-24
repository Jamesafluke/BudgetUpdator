namespace BudgetUpdatorUI;

partial class SettingsForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
        label1 = new Label();
        saveButton = new Button();
        deleteCsvsCheckBox = new CheckBox();
        selectPreviousMonthCheckBox = new CheckBox();
        taxAmountBox = new TextBox();
        taxAmountLabel = new Label();
        percentStaticLabel = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(44, 49);
        label1.Name = "label1";
        label1.Size = new Size(217, 21);
        label1.TabIndex = 0;
        label1.Text = "Tax amount for split calculator";
        // 
        // saveButton
        // 
        saveButton.Location = new Point(165, 311);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(93, 32);
        saveButton.TabIndex = 3;
        saveButton.Text = "Save";
        saveButton.UseVisualStyleBackColor = true;
        saveButton.Click += saveButton_Click;
        // 
        // deleteCsvsCheckBox
        // 
        deleteCsvsCheckBox.AutoSize = true;
        deleteCsvsCheckBox.Checked = true;
        deleteCsvsCheckBox.CheckState = CheckState.Checked;
        deleteCsvsCheckBox.Location = new Point(44, 131);
        deleteCsvsCheckBox.Name = "deleteCsvsCheckBox";
        deleteCsvsCheckBox.Size = new Size(214, 25);
        deleteCsvsCheckBox.TabIndex = 1;
        deleteCsvsCheckBox.Text = "Delete CSVs after updating";
        deleteCsvsCheckBox.UseVisualStyleBackColor = true;
        // 
        // selectPreviousMonthCheckBox
        // 
        selectPreviousMonthCheckBox.AutoSize = true;
        selectPreviousMonthCheckBox.Location = new Point(44, 162);
        selectPreviousMonthCheckBox.Name = "selectPreviousMonthCheckBox";
        selectPreviousMonthCheckBox.Size = new Size(184, 25);
        selectPreviousMonthCheckBox.TabIndex = 2;
        selectPreviousMonthCheckBox.Text = "Select previous month";
        selectPreviousMonthCheckBox.UseVisualStyleBackColor = true;
        // 
        // taxAmountBox
        // 
        taxAmountBox.Location = new Point(86, 78);
        taxAmountBox.Name = "taxAmountBox";
        taxAmountBox.Size = new Size(47, 29);
        taxAmountBox.TabIndex = 4;
        // 
        // taxAmountLabel
        // 
        taxAmountLabel.AutoSize = true;
        taxAmountLabel.ForeColor = Color.DarkGray;
        taxAmountLabel.Location = new Point(168, 81);
        taxAmountLabel.Name = "taxAmountLabel";
        taxAmountLabel.Size = new Size(123, 21);
        taxAmountLabel.TabIndex = 5;
        taxAmountLabel.Text = "taxAmountLabel";
        // 
        // percentStaticLabel
        // 
        percentStaticLabel.AutoSize = true;
        percentStaticLabel.Location = new Point(139, 81);
        percentStaticLabel.Name = "percentStaticLabel";
        percentStaticLabel.Size = new Size(23, 21);
        percentStaticLabel.TabIndex = 6;
        percentStaticLabel.Text = "%";
        // 
        // SettingsForm
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(425, 393);
        Controls.Add(percentStaticLabel);
        Controls.Add(taxAmountLabel);
        Controls.Add(taxAmountBox);
        Controls.Add(selectPreviousMonthCheckBox);
        Controls.Add(deleteCsvsCheckBox);
        Controls.Add(saveButton);
        Controls.Add(label1);
        Font = new Font("Segoe UI", 12F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(4);
        Name = "SettingsForm";
        Text = "Settings";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button saveButton;
    private CheckBox deleteCsvsCheckBox;
    private CheckBox selectPreviousMonthCheckBox;
    private TextBox taxAmountBox;
    private Label taxAmountLabel;
    private Label percentStaticLabel;
}