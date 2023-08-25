namespace BG3LootTableGenerator
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            itemsGrid = new DataGridView();
            nameColumn = new DataGridViewTextBoxColumn();
            inheritanceColumn = new DataGridViewTextBoxColumn();
            mapKeyColumn = new DataGridViewTextBoxColumn();
            pathColumn = new DataGridViewTextBoxColumn();
            dataColumn = new DataGridViewTextBoxColumn();
            localizationColumn = new DataGridViewTextBoxColumn();
            inheritanceLabel = new TextBox();
            nameDescriptorLabel = new Label();
            inheritanceDescriptorLabel = new Label();
            mapKeyDescriptorLabel = new Label();
            nameLabel = new TextBox();
            mapKeyLabel = new TextBox();
            pathDescriptorLabel = new Label();
            dataDescriptorLabel = new Label();
            localizationDescriptorLabel = new Label();
            pathTextBox = new TextBox();
            dataTextBox = new TextBox();
            localizationTextBox = new TextBox();
            searchBox = new TextBox();
            searchButton = new Button();
            loadTagsButton = new Button();
            tagList = new ListBox();
            loadXmlButton = new Button();
            ((System.ComponentModel.ISupportInitialize)itemsGrid).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(42, 12);
            button1.Name = "button1";
            button1.Size = new Size(226, 50);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(42, 80);
            button2.Name = "button2";
            button2.Size = new Size(226, 49);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(42, 138);
            button3.Name = "button3";
            button3.Size = new Size(226, 59);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // itemsGrid
            // 
            itemsGrid.AccessibleName = "";
            itemsGrid.AccessibleRole = AccessibleRole.Text;
            itemsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            itemsGrid.BackgroundColor = SystemColors.ControlLight;
            itemsGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            itemsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            itemsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemsGrid.Columns.AddRange(new DataGridViewColumn[] { nameColumn, inheritanceColumn, mapKeyColumn, pathColumn, dataColumn, localizationColumn });
            itemsGrid.Location = new Point(42, 499);
            itemsGrid.Name = "itemsGrid";
            itemsGrid.RowHeadersWidth = 62;
            itemsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            itemsGrid.Size = new Size(1450, 337);
            itemsGrid.TabIndex = 3;
            itemsGrid.CellContentClick += itemsGrid_CellContentClick;
            itemsGrid.SelectionChanged += itemsGrid_SelectionChanged;
            // 
            // nameColumn
            // 
            nameColumn.HeaderText = "Name";
            nameColumn.MinimumWidth = 8;
            nameColumn.Name = "nameColumn";
            nameColumn.ReadOnly = true;
            // 
            // inheritanceColumn
            // 
            inheritanceColumn.HeaderText = "Inheritance";
            inheritanceColumn.MinimumWidth = 8;
            inheritanceColumn.Name = "inheritanceColumn";
            inheritanceColumn.ReadOnly = true;
            // 
            // mapKeyColumn
            // 
            mapKeyColumn.HeaderText = "Map Key";
            mapKeyColumn.MinimumWidth = 8;
            mapKeyColumn.Name = "mapKeyColumn";
            mapKeyColumn.ReadOnly = true;
            // 
            // pathColumn
            // 
            pathColumn.HeaderText = "Path";
            pathColumn.MinimumWidth = 8;
            pathColumn.Name = "pathColumn";
            pathColumn.ReadOnly = true;
            // 
            // dataColumn
            // 
            dataColumn.HeaderText = "Data";
            dataColumn.MinimumWidth = 8;
            dataColumn.Name = "dataColumn";
            dataColumn.ReadOnly = true;
            // 
            // localizationColumn
            // 
            localizationColumn.HeaderText = "Localization";
            localizationColumn.MinimumWidth = 8;
            localizationColumn.Name = "localizationColumn";
            localizationColumn.ReadOnly = true;
            // 
            // inheritanceLabel
            // 
            inheritanceLabel.Location = new Point(960, 332);
            inheritanceLabel.Name = "inheritanceLabel";
            inheritanceLabel.Size = new Size(532, 31);
            inheritanceLabel.TabIndex = 4;
            inheritanceLabel.TextChanged += inheritanceLabel_TextChanged;
            // 
            // nameDescriptorLabel
            // 
            nameDescriptorLabel.AutoSize = true;
            nameDescriptorLabel.Location = new Point(855, 403);
            nameDescriptorLabel.Name = "nameDescriptorLabel";
            nameDescriptorLabel.Size = new Size(63, 25);
            nameDescriptorLabel.TabIndex = 5;
            nameDescriptorLabel.Text = "Name:";
            nameDescriptorLabel.Click += label1_Click;
            // 
            // inheritanceDescriptorLabel
            // 
            inheritanceDescriptorLabel.AutoSize = true;
            inheritanceDescriptorLabel.Location = new Point(852, 338);
            inheritanceDescriptorLabel.Name = "inheritanceDescriptorLabel";
            inheritanceDescriptorLabel.Size = new Size(102, 25);
            inheritanceDescriptorLabel.TabIndex = 6;
            inheritanceDescriptorLabel.Text = "Inheritance:";
            inheritanceDescriptorLabel.Click += inheritanceDescriptorLabel_Click;
            // 
            // mapKeyDescriptorLabel
            // 
            mapKeyDescriptorLabel.AutoSize = true;
            mapKeyDescriptorLabel.Location = new Point(855, 460);
            mapKeyDescriptorLabel.Name = "mapKeyDescriptorLabel";
            mapKeyDescriptorLabel.Size = new Size(85, 25);
            mapKeyDescriptorLabel.TabIndex = 7;
            mapKeyDescriptorLabel.Text = "Map Key:";
            mapKeyDescriptorLabel.Click += label2_Click;
            // 
            // nameLabel
            // 
            nameLabel.Location = new Point(924, 400);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(568, 31);
            nameLabel.TabIndex = 8;
            nameLabel.TextChanged += nameLabel_TextChanged;
            // 
            // mapKeyLabel
            // 
            mapKeyLabel.Location = new Point(946, 457);
            mapKeyLabel.Name = "mapKeyLabel";
            mapKeyLabel.Size = new Size(546, 31);
            mapKeyLabel.TabIndex = 9;
            mapKeyLabel.TextChanged += mapKeyLabel_TextChanged;
            // 
            // pathDescriptorLabel
            // 
            pathDescriptorLabel.AutoSize = true;
            pathDescriptorLabel.Location = new Point(852, 67);
            pathDescriptorLabel.Name = "pathDescriptorLabel";
            pathDescriptorLabel.Size = new Size(50, 25);
            pathDescriptorLabel.TabIndex = 10;
            pathDescriptorLabel.Text = "Path:";
            pathDescriptorLabel.Click += label1_Click_1;
            // 
            // dataDescriptorLabel
            // 
            dataDescriptorLabel.AutoSize = true;
            dataDescriptorLabel.Location = new Point(852, 104);
            dataDescriptorLabel.Name = "dataDescriptorLabel";
            dataDescriptorLabel.Size = new Size(53, 25);
            dataDescriptorLabel.TabIndex = 11;
            dataDescriptorLabel.Text = "Data:";
            // 
            // localizationDescriptorLabel
            // 
            localizationDescriptorLabel.AutoSize = true;
            localizationDescriptorLabel.Location = new Point(852, 138);
            localizationDescriptorLabel.Name = "localizationDescriptorLabel";
            localizationDescriptorLabel.Size = new Size(108, 25);
            localizationDescriptorLabel.TabIndex = 12;
            localizationDescriptorLabel.Text = "Localization:";
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(910, 67);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(588, 31);
            pathTextBox.TabIndex = 13;
            // 
            // dataTextBox
            // 
            dataTextBox.Location = new Point(910, 104);
            dataTextBox.Name = "dataTextBox";
            dataTextBox.Size = new Size(588, 31);
            dataTextBox.TabIndex = 14;
            // 
            // localizationTextBox
            // 
            localizationTextBox.Location = new Point(852, 166);
            localizationTextBox.Name = "localizationTextBox";
            localizationTextBox.Size = new Size(646, 31);
            localizationTextBox.TabIndex = 15;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(160, 272);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(430, 31);
            searchBox.TabIndex = 16;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(42, 272);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(112, 34);
            searchButton.TabIndex = 17;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // loadTagsButton
            // 
            loadTagsButton.Location = new Point(42, 316);
            loadTagsButton.Name = "loadTagsButton";
            loadTagsButton.Size = new Size(112, 34);
            loadTagsButton.TabIndex = 18;
            loadTagsButton.Text = "Load Tags";
            loadTagsButton.UseVisualStyleBackColor = true;
            loadTagsButton.Click += LoadTagsButton_Click;
            // 
            // tagList
            // 
            tagList.FormattingEnabled = true;
            tagList.ItemHeight = 25;
            tagList.Location = new Point(42, 356);
            tagList.Name = "tagList";
            tagList.Size = new Size(807, 129);
            tagList.TabIndex = 19;
            tagList.SelectedIndexChanged += tagsList_SelectedIndexChanged;
            // 
            // loadXmlButton
            // 
            loadXmlButton.Location = new Point(42, 222);
            loadXmlButton.Name = "loadXmlButton";
            loadXmlButton.Size = new Size(112, 34);
            loadXmlButton.TabIndex = 20;
            loadXmlButton.Text = "Load XML";
            loadXmlButton.UseVisualStyleBackColor = true;
            loadXmlButton.Click += loadXmlButton_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1510, 864);
            Controls.Add(loadXmlButton);
            Controls.Add(tagList);
            Controls.Add(loadTagsButton);
            Controls.Add(searchButton);
            Controls.Add(searchBox);
            Controls.Add(localizationTextBox);
            Controls.Add(dataTextBox);
            Controls.Add(pathTextBox);
            Controls.Add(localizationDescriptorLabel);
            Controls.Add(dataDescriptorLabel);
            Controls.Add(pathDescriptorLabel);
            Controls.Add(mapKeyLabel);
            Controls.Add(nameLabel);
            Controls.Add(mapKeyDescriptorLabel);
            Controls.Add(inheritanceDescriptorLabel);
            Controls.Add(nameDescriptorLabel);
            Controls.Add(inheritanceLabel);
            Controls.Add(itemsGrid);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "BG3SortGenTool";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)itemsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView itemsGrid;
        private DataGridViewTextBoxColumn nameColumn;
        private DataGridViewTextBoxColumn inheritanceColumn;
        private DataGridViewTextBoxColumn mapKeyColumn;
        private DataGridViewTextBoxColumn pathColumn;
        private DataGridViewTextBoxColumn dataColumn;
        private DataGridViewTextBoxColumn localizationColumn;
        private TextBox inheritanceLabel;
        private Label nameDescriptorLabel;
        private Label inheritanceDescriptorLabel;
        private Label mapKeyDescriptorLabel;
        private TextBox nameLabel;
        private TextBox mapKeyLabel;
        private Label pathDescriptorLabel;
        private Label dataDescriptorLabel;
        private Label localizationDescriptorLabel;
        private TextBox pathTextBox;
        private TextBox dataTextBox;
        private TextBox localizationTextBox;
        private TextBox searchBox;
        private Button searchButton;
        private Button loadTagsButton;
        private ListBox tagList;
        private Button loadXmlButton;
    }
}