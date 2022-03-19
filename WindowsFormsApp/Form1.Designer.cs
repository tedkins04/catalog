namespace WindowsFormsApp
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.searchItem1 = new WindowsFormsApp.Controls.Pages.SearchItem();
            this.reviewItem1 = new WindowsFormsApp.Controls.Pages.ReviewItem();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.searchItem1);
            this.mainPanel.Controls.Add(this.reviewItem1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(884, 559);
            this.mainPanel.TabIndex = 2;
            // 
            // searchItem1
            // 
            this.searchItem1.Location = new System.Drawing.Point(13, 12);
            this.searchItem1.Name = "searchItem1";
            this.searchItem1.Size = new System.Drawing.Size(859, 534);
            this.searchItem1.TabIndex = 1;
            // 
            // reviewItem1
            // 
            this.reviewItem1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.reviewItem1.Location = new System.Drawing.Point(13, 13);
            this.reviewItem1.Name = "reviewItem1";
            this.reviewItem1.Size = new System.Drawing.Size(859, 534);
            this.reviewItem1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 559);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(900, 598);
            this.Name = "Form1";
            this.Text = "Catalog";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private Controls.Pages.SearchItem searchItem1;
        private Controls.Pages.ReviewItem reviewItem1;
    }
}

