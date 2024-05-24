namespace BudgetUpdatorUI;

partial class MenuForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
        updateBudgetButton = new Button();
        splitAnItemButton = new Button();
        completeItemsButton = new Button();
        menuStrip1 = new MenuStrip();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem1 = new ToolStripMenuItem();
        exportToolStripMenuItem = new ToolStripMenuItem();
        exportCurrentMonthToCSVToolStripMenuItem = new ToolStripMenuItem();
        exportTwoMonthsToCSVToolStripMenuItem = new ToolStripMenuItem();
        exportAllToCSVToolStripMenuItem = new ToolStripMenuItem();
        deleteCSVsToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        closeToolStripMenuItem = new ToolStripMenuItem();
        refreshToolStripMenuItem = new ToolStripMenuItem();
        itemsToolStripMenuItem = new ToolStripMenuItem();
        addItemToolStripMenuItem = new ToolStripMenuItem();
        changeItemToolStripMenuItem = new ToolStripMenuItem();
        modifyItemToolStripMenuItem = new ToolStripMenuItem();
        splitItemToolStripMenuItem = new ToolStripMenuItem();
        deleteItemToolStripMenuItem = new ToolStripMenuItem();
        recheckXLSXToolStripMenuItem = new ToolStripMenuItem();
        listAllItemsToolStripMenuItem = new ToolStripMenuItem();
        clearDatabaseToolStripMenuItem = new ToolStripMenuItem();
        updateBudgetLabel = new Label();
        completeItemsLabel = new Label();
        splitAnItemLabel = new Label();
        lastUpdateLabel = new Label();
        lastUpdatedStaticLabel = new Label();
        downloadCsvsLabel = new Label();
        downloadCsvsButton = new Button();
        dateStaticLabel = new Label();
        dateLabel = new Label();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // updateBudgetButton
        // 
        updateBudgetButton.Enabled = false;
        updateBudgetButton.Location = new Point(68, 128);
        updateBudgetButton.Margin = new Padding(4);
        updateBudgetButton.Name = "updateBudgetButton";
        updateBudgetButton.Size = new Size(210, 62);
        updateBudgetButton.TabIndex = 1;
        updateBudgetButton.Text = "&Update Budget";
        updateBudgetButton.UseVisualStyleBackColor = true;
        updateBudgetButton.Click += updateBudgetButton_Click;
        // 
        // splitAnItemButton
        // 
        splitAnItemButton.Location = new Point(68, 338);
        splitAnItemButton.Margin = new Padding(4);
        splitAnItemButton.Name = "splitAnItemButton";
        splitAnItemButton.Size = new Size(210, 62);
        splitAnItemButton.TabIndex = 4;
        splitAnItemButton.Text = "&Split an Item";
        splitAnItemButton.UseVisualStyleBackColor = true;
        // 
        // completeItemsButton
        // 
        completeItemsButton.Enabled = false;
        completeItemsButton.Location = new Point(67, 268);
        completeItemsButton.Margin = new Padding(4);
        completeItemsButton.Name = "completeItemsButton";
        completeItemsButton.Size = new Size(210, 62);
        completeItemsButton.TabIndex = 3;
        completeItemsButton.Text = "&Complete Items";
        completeItemsButton.UseVisualStyleBackColor = true;
        completeItemsButton.Click += completeItemsButton_Click;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, itemsToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(510, 24);
        menuStrip1.TabIndex = 5;
        menuStrip1.Text = "menuStrip1";
        // 
        // settingsToolStripMenuItem
        // 
        settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem1, exportToolStripMenuItem, deleteCSVsToolStripMenuItem, aboutToolStripMenuItem, closeToolStripMenuItem, refreshToolStripMenuItem });
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(61, 20);
        settingsToolStripMenuItem.Text = "&Settings";
        // 
        // settingsToolStripMenuItem1
        // 
        settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
        settingsToolStripMenuItem1.Size = new Size(136, 22);
        settingsToolStripMenuItem1.Text = "&Settings";
        settingsToolStripMenuItem1.Click += settingsToolStripMenuItem1_Click;
        // 
        // exportToolStripMenuItem
        // 
        exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportCurrentMonthToCSVToolStripMenuItem, exportTwoMonthsToCSVToolStripMenuItem, exportAllToCSVToolStripMenuItem });
        exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        exportToolStripMenuItem.Size = new Size(136, 22);
        exportToolStripMenuItem.Text = "&Export...";
        // 
        // exportCurrentMonthToCSVToolStripMenuItem
        // 
        exportCurrentMonthToCSVToolStripMenuItem.Name = "exportCurrentMonthToCSVToolStripMenuItem";
        exportCurrentMonthToCSVToolStripMenuItem.Size = new Size(228, 22);
        exportCurrentMonthToCSVToolStripMenuItem.Text = "Export Current Month to CSV";
        // 
        // exportTwoMonthsToCSVToolStripMenuItem
        // 
        exportTwoMonthsToCSVToolStripMenuItem.Name = "exportTwoMonthsToCSVToolStripMenuItem";
        exportTwoMonthsToCSVToolStripMenuItem.Size = new Size(228, 22);
        exportTwoMonthsToCSVToolStripMenuItem.Text = "Export Two Months to CSV";
        // 
        // exportAllToCSVToolStripMenuItem
        // 
        exportAllToCSVToolStripMenuItem.Name = "exportAllToCSVToolStripMenuItem";
        exportAllToCSVToolStripMenuItem.Size = new Size(228, 22);
        exportAllToCSVToolStripMenuItem.Text = "Export All to CSV";
        // 
        // deleteCSVsToolStripMenuItem
        // 
        deleteCSVsToolStripMenuItem.Name = "deleteCSVsToolStripMenuItem";
        deleteCSVsToolStripMenuItem.Size = new Size(136, 22);
        deleteCSVsToolStripMenuItem.Text = "Delete CSVs";
        // 
        // aboutToolStripMenuItem
        // 
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(136, 22);
        aboutToolStripMenuItem.Text = "About";
        aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
        // 
        // closeToolStripMenuItem
        // 
        closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        closeToolStripMenuItem.Size = new Size(136, 22);
        closeToolStripMenuItem.Text = "Close";
        // 
        // refreshToolStripMenuItem
        // 
        refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
        refreshToolStripMenuItem.Size = new Size(136, 22);
        refreshToolStripMenuItem.Text = "Refresh";
        refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
        // 
        // itemsToolStripMenuItem
        // 
        itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addItemToolStripMenuItem, changeItemToolStripMenuItem, modifyItemToolStripMenuItem, splitItemToolStripMenuItem, deleteItemToolStripMenuItem, recheckXLSXToolStripMenuItem, listAllItemsToolStripMenuItem, clearDatabaseToolStripMenuItem });
        itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
        itemsToolStripMenuItem.Size = new Size(48, 20);
        itemsToolStripMenuItem.Text = "&Items";
        // 
        // addItemToolStripMenuItem
        // 
        addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
        addItemToolStripMenuItem.Size = new Size(151, 22);
        addItemToolStripMenuItem.Text = "Add Item";
        // 
        // changeItemToolStripMenuItem
        // 
        changeItemToolStripMenuItem.Name = "changeItemToolStripMenuItem";
        changeItemToolStripMenuItem.Size = new Size(151, 22);
        changeItemToolStripMenuItem.Text = "Change Item";
        // 
        // modifyItemToolStripMenuItem
        // 
        modifyItemToolStripMenuItem.Name = "modifyItemToolStripMenuItem";
        modifyItemToolStripMenuItem.Size = new Size(151, 22);
        modifyItemToolStripMenuItem.Text = "Modify Item";
        // 
        // splitItemToolStripMenuItem
        // 
        splitItemToolStripMenuItem.Name = "splitItemToolStripMenuItem";
        splitItemToolStripMenuItem.Size = new Size(151, 22);
        splitItemToolStripMenuItem.Text = "Split Item";
        // 
        // deleteItemToolStripMenuItem
        // 
        deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
        deleteItemToolStripMenuItem.Size = new Size(151, 22);
        deleteItemToolStripMenuItem.Text = "Delete Item";
        // 
        // recheckXLSXToolStripMenuItem
        // 
        recheckXLSXToolStripMenuItem.Name = "recheckXLSXToolStripMenuItem";
        recheckXLSXToolStripMenuItem.Size = new Size(151, 22);
        recheckXLSXToolStripMenuItem.Text = "Recheck XLSX";
        // 
        // listAllItemsToolStripMenuItem
        // 
        listAllItemsToolStripMenuItem.Name = "listAllItemsToolStripMenuItem";
        listAllItemsToolStripMenuItem.Size = new Size(151, 22);
        listAllItemsToolStripMenuItem.Text = "List All Items";
        listAllItemsToolStripMenuItem.Click += listAllItemsToolStripMenuItem_Click;
        // 
        // clearDatabaseToolStripMenuItem
        // 
        clearDatabaseToolStripMenuItem.Name = "clearDatabaseToolStripMenuItem";
        clearDatabaseToolStripMenuItem.Size = new Size(151, 22);
        clearDatabaseToolStripMenuItem.Text = "Clear database";
        clearDatabaseToolStripMenuItem.Click += clearDatabaseToolStripMenuItem_Click;
        // 
        // updateBudgetLabel
        // 
        updateBudgetLabel.AutoSize = true;
        updateBudgetLabel.Font = new Font("Segoe UI", 10F);
        updateBudgetLabel.ForeColor = Color.DarkGray;
        updateBudgetLabel.Location = new Point(285, 149);
        updateBudgetLabel.Name = "updateBudgetLabel";
        updateBudgetLabel.Size = new Size(128, 19);
        updateBudgetLabel.TabIndex = 6;
        updateBudgetLabel.Text = "updateBudgetLabel";
        // 
        // completeItemsLabel
        // 
        completeItemsLabel.AutoSize = true;
        completeItemsLabel.Font = new Font("Segoe UI", 10F);
        completeItemsLabel.ForeColor = Color.DarkGray;
        completeItemsLabel.Location = new Point(284, 289);
        completeItemsLabel.Name = "completeItemsLabel";
        completeItemsLabel.Size = new Size(97, 19);
        completeItemsLabel.TabIndex = 8;
        completeItemsLabel.Text = "completeLabel";
        // 
        // splitAnItemLabel
        // 
        splitAnItemLabel.AutoSize = true;
        splitAnItemLabel.Font = new Font("Segoe UI", 10F);
        splitAnItemLabel.ForeColor = Color.DarkGray;
        splitAnItemLabel.Location = new Point(285, 359);
        splitAnItemLabel.Name = "splitAnItemLabel";
        splitAnItemLabel.Size = new Size(66, 19);
        splitAnItemLabel.TabIndex = 9;
        splitAnItemLabel.Text = "splitLabel";
        // 
        // lastUpdateLabel
        // 
        lastUpdateLabel.AutoSize = true;
        lastUpdateLabel.Location = new Point(225, 424);
        lastUpdateLabel.Name = "lastUpdateLabel";
        lastUpdateLabel.Size = new Size(130, 21);
        lastUpdateLabel.TabIndex = 10;
        lastUpdateLabel.Text = "lastUpdatedLabel";
        // 
        // lastUpdatedStaticLabel
        // 
        lastUpdatedStaticLabel.AutoSize = true;
        lastUpdatedStaticLabel.ForeColor = SystemColors.ControlDark;
        lastUpdatedStaticLabel.Location = new Point(115, 424);
        lastUpdatedStaticLabel.Name = "lastUpdatedStaticLabel";
        lastUpdatedStaticLabel.Size = new Size(104, 21);
        lastUpdatedStaticLabel.TabIndex = 11;
        lastUpdatedStaticLabel.Text = "Last Updated:";
        // 
        // downloadCsvsLabel
        // 
        downloadCsvsLabel.AutoSize = true;
        downloadCsvsLabel.Font = new Font("Segoe UI", 10F);
        downloadCsvsLabel.ForeColor = Color.DarkGray;
        downloadCsvsLabel.Location = new Point(285, 79);
        downloadCsvsLabel.Name = "downloadCsvsLabel";
        downloadCsvsLabel.Size = new Size(129, 19);
        downloadCsvsLabel.TabIndex = 13;
        downloadCsvsLabel.Text = "downloadCsvsLabel";
        // 
        // downloadCsvsButton
        // 
        downloadCsvsButton.Location = new Point(68, 58);
        downloadCsvsButton.Margin = new Padding(4);
        downloadCsvsButton.Name = "downloadCsvsButton";
        downloadCsvsButton.Size = new Size(210, 62);
        downloadCsvsButton.TabIndex = 0;
        downloadCsvsButton.Text = "&Download CSVs";
        downloadCsvsButton.UseVisualStyleBackColor = true;
        downloadCsvsButton.Click += downloadCsvsButton_Click;
        // 
        // dateStaticLabel
        // 
        dateStaticLabel.AutoSize = true;
        dateStaticLabel.ForeColor = SystemColors.ControlDark;
        dateStaticLabel.Location = new Point(115, 458);
        dateStaticLabel.Name = "dateStaticLabel";
        dateStaticLabel.Size = new Size(45, 21);
        dateStaticLabel.TabIndex = 15;
        dateStaticLabel.Text = "Date:";
        // 
        // dateLabel
        // 
        dateLabel.AutoSize = true;
        dateLabel.Location = new Point(225, 458);
        dateLabel.Name = "dateLabel";
        dateLabel.Size = new Size(77, 21);
        dateLabel.TabIndex = 14;
        dateLabel.Text = "dateLabel";
        // 
        // MenuForm
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(510, 525);
        Controls.Add(dateStaticLabel);
        Controls.Add(dateLabel);
        Controls.Add(downloadCsvsLabel);
        Controls.Add(downloadCsvsButton);
        Controls.Add(lastUpdatedStaticLabel);
        Controls.Add(lastUpdateLabel);
        Controls.Add(splitAnItemLabel);
        Controls.Add(completeItemsLabel);
        Controls.Add(updateBudgetLabel);
        Controls.Add(completeItemsButton);
        Controls.Add(splitAnItemButton);
        Controls.Add(updateBudgetButton);
        Controls.Add(menuStrip1);
        Font = new Font("Segoe UI", 12F);
        Icon = (Icon)resources.GetObject("$this.Icon");
        KeyPreview = true;
        MainMenuStrip = menuStrip1;
        Margin = new Padding(4);
        MaximizeBox = false;
        Name = "MenuForm";
        Text = "Budgetinator";
        Load += Menu_Load;
        KeyDown += MenuForm_KeyDown;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button updateBudgetButton;
    private Button splitAnItemButton;
    private Button completeItemsButton;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripMenuItem settingsToolStripMenuItem1;
    private ToolStripMenuItem exportToolStripMenuItem;
    private ToolStripMenuItem deleteCSVsToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripMenuItem itemsToolStripMenuItem;
    private ToolStripMenuItem addItemToolStripMenuItem;
    private ToolStripMenuItem changeItemToolStripMenuItem;
    private ToolStripMenuItem modifyItemToolStripMenuItem;
    private ToolStripMenuItem splitItemToolStripMenuItem;
    private ToolStripMenuItem deleteItemToolStripMenuItem;
    private ToolStripMenuItem recheckXLSXToolStripMenuItem;
    private ToolStripMenuItem closeToolStripMenuItem;
    private Label updateBudgetLabel;
    private Label completeItemsLabel;
    private Label splitAnItemLabel;
    private Label lastUpdateLabel;
    private Label lastUpdatedStaticLabel;
    private Label downloadCsvsLabel;
    private Button downloadCsvsButton;
    private Label dateStaticLabel;
    private Label dateLabel;
    private ToolStripMenuItem exportCurrentMonthToCSVToolStripMenuItem;
    private ToolStripMenuItem exportTwoMonthsToCSVToolStripMenuItem;
    private ToolStripMenuItem exportAllToCSVToolStripMenuItem;
    private ToolStripMenuItem refreshToolStripMenuItem;
    private ToolStripMenuItem listAllItemsToolStripMenuItem;
    private ToolStripMenuItem clearDatabaseToolStripMenuItem;
}
