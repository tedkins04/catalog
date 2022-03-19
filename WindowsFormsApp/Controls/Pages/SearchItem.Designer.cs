namespace WindowsFormsApp.Controls.Pages
{
    partial class SearchItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.filters = new System.Windows.Forms.Panel();
            this.orderByGroup = new System.Windows.Forms.GroupBox();
            this.orderByDesc = new System.Windows.Forms.RadioButton();
            this.orderByAsc = new System.Windows.Forms.RadioButton();
            this.searchGroup = new System.Windows.Forms.GroupBox();
            this.useOtherFillters = new System.Windows.Forms.CheckBox();
            this.searchInEverything = new System.Windows.Forms.RadioButton();
            this.searchInTitles = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.typeGroup = new System.Windows.Forms.GroupBox();
            this.showMovies = new System.Windows.Forms.CheckBox();
            this.showBooks = new System.Windows.Forms.CheckBox();
            this.categoryGroup = new System.Windows.Forms.GroupBox();
            this.selectAllCategories = new System.Windows.Forms.CheckBox();
            this.selectCategories = new System.Windows.Forms.CheckedListBox();
            this.priceGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.enterMaxPrice = new System.Windows.Forms.TextBox();
            this.enterMinPrice = new System.Windows.Forms.TextBox();
            this.applyFilters = new System.Windows.Forms.Button();
            this.clearFilters = new System.Windows.Forms.Button();
            this.displayItems = new WindowsFormsApp.Controls.ListItems();
            this.filters.SuspendLayout();
            this.orderByGroup.SuspendLayout();
            this.searchGroup.SuspendLayout();
            this.typeGroup.SuspendLayout();
            this.categoryGroup.SuspendLayout();
            this.priceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // filters
            // 
            this.filters.AutoScroll = true;
            this.filters.BackColor = System.Drawing.SystemColors.Control;
            this.filters.Controls.Add(this.orderByGroup);
            this.filters.Controls.Add(this.searchGroup);
            this.filters.Controls.Add(this.typeGroup);
            this.filters.Controls.Add(this.categoryGroup);
            this.filters.Controls.Add(this.priceGroup);
            this.filters.Location = new System.Drawing.Point(3, 3);
            this.filters.Name = "filters";
            this.filters.Size = new System.Drawing.Size(184, 494);
            this.filters.TabIndex = 3;
            // 
            // orderByGroup
            // 
            this.orderByGroup.Controls.Add(this.orderByDesc);
            this.orderByGroup.Controls.Add(this.orderByAsc);
            this.orderByGroup.Location = new System.Drawing.Point(13, 389);
            this.orderByGroup.Name = "orderByGroup";
            this.orderByGroup.Size = new System.Drawing.Size(165, 97);
            this.orderByGroup.TabIndex = 9;
            this.orderByGroup.TabStop = false;
            this.orderByGroup.Text = "Order By";
            // 
            // orderByDesc
            // 
            this.orderByDesc.AutoSize = true;
            this.orderByDesc.Location = new System.Drawing.Point(60, 20);
            this.orderByDesc.Name = "orderByDesc";
            this.orderByDesc.Size = new System.Drawing.Size(54, 17);
            this.orderByDesc.TabIndex = 1;
            this.orderByDesc.Text = "DESC";
            this.orderByDesc.UseVisualStyleBackColor = true;
            // 
            // orderByAsc
            // 
            this.orderByAsc.AutoSize = true;
            this.orderByAsc.Checked = true;
            this.orderByAsc.Location = new System.Drawing.Point(7, 20);
            this.orderByAsc.Name = "orderByAsc";
            this.orderByAsc.Size = new System.Drawing.Size(46, 17);
            this.orderByAsc.TabIndex = 0;
            this.orderByAsc.TabStop = true;
            this.orderByAsc.Text = "ASC";
            this.orderByAsc.UseVisualStyleBackColor = true;
            // 
            // searchGroup
            // 
            this.searchGroup.Controls.Add(this.useOtherFillters);
            this.searchGroup.Controls.Add(this.searchInEverything);
            this.searchGroup.Controls.Add(this.searchInTitles);
            this.searchGroup.Controls.Add(this.label3);
            this.searchGroup.Controls.Add(this.searchBox);
            this.searchGroup.Location = new System.Drawing.Point(4, 4);
            this.searchGroup.Name = "searchGroup";
            this.searchGroup.Size = new System.Drawing.Size(174, 108);
            this.searchGroup.TabIndex = 8;
            this.searchGroup.TabStop = false;
            this.searchGroup.Text = "Search";
            // 
            // useOtherFillters
            // 
            this.useOtherFillters.AutoSize = true;
            this.useOtherFillters.Checked = true;
            this.useOtherFillters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useOtherFillters.Location = new System.Drawing.Point(14, 83);
            this.useOtherFillters.Name = "useOtherFillters";
            this.useOtherFillters.Size = new System.Drawing.Size(101, 17);
            this.useOtherFillters.TabIndex = 2;
            this.useOtherFillters.Text = "Use other fillters";
            this.useOtherFillters.UseVisualStyleBackColor = true;
            this.useOtherFillters.CheckedChanged += new System.EventHandler(this.useOtherFillters_CheckedChanged);
            // 
            // searchInEverything
            // 
            this.searchInEverything.AutoSize = true;
            this.searchInEverything.Checked = true;
            this.searchInEverything.Location = new System.Drawing.Point(13, 60);
            this.searchInEverything.Name = "searchInEverything";
            this.searchInEverything.Size = new System.Drawing.Size(75, 17);
            this.searchInEverything.TabIndex = 12;
            this.searchInEverything.TabStop = true;
            this.searchInEverything.Text = "Everything";
            this.searchInEverything.UseVisualStyleBackColor = true;
            this.searchInEverything.CheckedChanged += new System.EventHandler(this.searchInEverything_CheckedChanged);
            // 
            // searchInTitles
            // 
            this.searchInTitles.AutoSize = true;
            this.searchInTitles.Location = new System.Drawing.Point(99, 60);
            this.searchInTitles.Name = "searchInTitles";
            this.searchInTitles.Size = new System.Drawing.Size(50, 17);
            this.searchInTitles.TabIndex = 11;
            this.searchInTitles.Text = "Titles";
            this.searchInTitles.UseVisualStyleBackColor = true;
            this.searchInTitles.CheckedChanged += new System.EventHandler(this.searchInTitles_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search In:";
            // 
            // searchBox
            // 
            this.searchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.searchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchBox.Location = new System.Drawing.Point(6, 19);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(159, 20);
            this.searchBox.TabIndex = 7;
            // 
            // typeGroup
            // 
            this.typeGroup.Controls.Add(this.showMovies);
            this.typeGroup.Controls.Add(this.showBooks);
            this.typeGroup.Location = new System.Drawing.Point(7, 118);
            this.typeGroup.Name = "typeGroup";
            this.typeGroup.Size = new System.Drawing.Size(174, 47);
            this.typeGroup.TabIndex = 6;
            this.typeGroup.TabStop = false;
            this.typeGroup.Text = "Type";
            // 
            // showMovies
            // 
            this.showMovies.AutoSize = true;
            this.showMovies.Checked = true;
            this.showMovies.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMovies.Location = new System.Drawing.Point(87, 20);
            this.showMovies.Name = "showMovies";
            this.showMovies.Size = new System.Drawing.Size(60, 17);
            this.showMovies.TabIndex = 1;
            this.showMovies.Text = "Movies";
            this.showMovies.UseVisualStyleBackColor = true;
            // 
            // showBooks
            // 
            this.showBooks.AutoSize = true;
            this.showBooks.Checked = true;
            this.showBooks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBooks.Location = new System.Drawing.Point(11, 19);
            this.showBooks.Name = "showBooks";
            this.showBooks.Size = new System.Drawing.Size(56, 17);
            this.showBooks.TabIndex = 0;
            this.showBooks.Text = "Books";
            this.showBooks.UseVisualStyleBackColor = true;
            // 
            // categoryGroup
            // 
            this.categoryGroup.Controls.Add(this.selectAllCategories);
            this.categoryGroup.Controls.Add(this.selectCategories);
            this.categoryGroup.Location = new System.Drawing.Point(7, 246);
            this.categoryGroup.Name = "categoryGroup";
            this.categoryGroup.Size = new System.Drawing.Size(174, 136);
            this.categoryGroup.TabIndex = 5;
            this.categoryGroup.TabStop = false;
            this.categoryGroup.Text = "Category";
            // 
            // selectAllCategories
            // 
            this.selectAllCategories.AutoSize = true;
            this.selectAllCategories.Checked = true;
            this.selectAllCategories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectAllCategories.Location = new System.Drawing.Point(10, 19);
            this.selectAllCategories.Name = "selectAllCategories";
            this.selectAllCategories.Size = new System.Drawing.Size(70, 17);
            this.selectAllCategories.TabIndex = 2;
            this.selectAllCategories.Text = "Select All";
            this.selectAllCategories.UseVisualStyleBackColor = true;
            this.selectAllCategories.CheckedChanged += new System.EventHandler(this.selectAllCategories_CheckedChanged);
            // 
            // selectCategories
            // 
            this.selectCategories.CheckOnClick = true;
            this.selectCategories.FormattingEnabled = true;
            this.selectCategories.Location = new System.Drawing.Point(6, 37);
            this.selectCategories.Name = "selectCategories";
            this.selectCategories.Size = new System.Drawing.Size(165, 94);
            this.selectCategories.TabIndex = 1;
            // 
            // priceGroup
            // 
            this.priceGroup.Controls.Add(this.label2);
            this.priceGroup.Controls.Add(this.label1);
            this.priceGroup.Controls.Add(this.enterMaxPrice);
            this.priceGroup.Controls.Add(this.enterMinPrice);
            this.priceGroup.Location = new System.Drawing.Point(7, 171);
            this.priceGroup.Name = "priceGroup";
            this.priceGroup.Size = new System.Drawing.Size(174, 69);
            this.priceGroup.TabIndex = 4;
            this.priceGroup.TabStop = false;
            this.priceGroup.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min";
            // 
            // enterMaxPrice
            // 
            this.enterMaxPrice.Location = new System.Drawing.Point(81, 38);
            this.enterMaxPrice.Name = "enterMaxPrice";
            this.enterMaxPrice.Size = new System.Drawing.Size(63, 20);
            this.enterMaxPrice.TabIndex = 3;
            // 
            // enterMinPrice
            // 
            this.enterMinPrice.Location = new System.Drawing.Point(81, 12);
            this.enterMinPrice.Name = "enterMinPrice";
            this.enterMinPrice.Size = new System.Drawing.Size(63, 20);
            this.enterMinPrice.TabIndex = 2;
            // 
            // applyFilters
            // 
            this.applyFilters.Location = new System.Drawing.Point(91, 503);
            this.applyFilters.Name = "applyFilters";
            this.applyFilters.Size = new System.Drawing.Size(96, 26);
            this.applyFilters.TabIndex = 13;
            this.applyFilters.Text = "Apply";
            this.applyFilters.UseVisualStyleBackColor = true;
            this.applyFilters.Click += new System.EventHandler(this.applyFilters_Click);
            // 
            // clearFilters
            // 
            this.clearFilters.Location = new System.Drawing.Point(3, 503);
            this.clearFilters.Name = "clearFilters";
            this.clearFilters.Size = new System.Drawing.Size(87, 26);
            this.clearFilters.TabIndex = 14;
            this.clearFilters.Text = "Clear";
            this.clearFilters.UseVisualStyleBackColor = true;
            this.clearFilters.Click += new System.EventHandler(this.clearFilters_Click);
            // 
            // displayItems
            // 
            this.displayItems.AutoScroll = true;
            this.displayItems.BackColor = System.Drawing.Color.DarkGray;
            this.displayItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayItems.Location = new System.Drawing.Point(193, 3);
            this.displayItems.Name = "displayItems";
            this.displayItems.Size = new System.Drawing.Size(659, 526);
            this.displayItems.TabIndex = 15;
            this.displayItems.Load += new System.EventHandler(this.displayItems_Load);
            // 
            // SearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.displayItems);
            this.Controls.Add(this.clearFilters);
            this.Controls.Add(this.applyFilters);
            this.Controls.Add(this.filters);
            this.Name = "SearchItem";
            this.Size = new System.Drawing.Size(859, 534);
            this.filters.ResumeLayout(false);
            this.orderByGroup.ResumeLayout(false);
            this.orderByGroup.PerformLayout();
            this.searchGroup.ResumeLayout(false);
            this.searchGroup.PerformLayout();
            this.typeGroup.ResumeLayout(false);
            this.typeGroup.PerformLayout();
            this.categoryGroup.ResumeLayout(false);
            this.categoryGroup.PerformLayout();
            this.priceGroup.ResumeLayout(false);
            this.priceGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel filters;
        private System.Windows.Forms.GroupBox searchGroup;
        private System.Windows.Forms.CheckBox useOtherFillters;
        private System.Windows.Forms.RadioButton searchInEverything;
        private System.Windows.Forms.RadioButton searchInTitles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.GroupBox typeGroup;
        private System.Windows.Forms.CheckBox showMovies;
        private System.Windows.Forms.CheckBox showBooks;
        private System.Windows.Forms.GroupBox categoryGroup;
        private System.Windows.Forms.CheckBox selectAllCategories;
        private System.Windows.Forms.CheckedListBox selectCategories;
        private System.Windows.Forms.GroupBox priceGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox enterMaxPrice;
        private System.Windows.Forms.TextBox enterMinPrice;
        private System.Windows.Forms.Button applyFilters;
        private System.Windows.Forms.Button clearFilters;
        private ListItems displayItems;
        private System.Windows.Forms.GroupBox orderByGroup;
        private System.Windows.Forms.RadioButton orderByDesc;
        private System.Windows.Forms.RadioButton orderByAsc;
    }
}
