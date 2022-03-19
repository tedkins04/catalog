namespace WindowsFormsApp.Controls.Review
{
    partial class ReviewItemBook
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
            this.displayTitle = new System.Windows.Forms.Label();
            this.displayImage = new System.Windows.Forms.PictureBox();
            this.displayAuthor = new System.Windows.Forms.Label();
            this.displayPublisher = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.displayPages = new System.Windows.Forms.Label();
            this.displayPublicationYear = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.displayPrice = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.displayCategories = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.displayImage)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTitle
            // 
            this.displayTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTitle.Location = new System.Drawing.Point(235, 20);
            this.displayTitle.Name = "displayTitle";
            this.displayTitle.Size = new System.Drawing.Size(483, 119);
            this.displayTitle.TabIndex = 0;
            this.displayTitle.Text = "title";
            this.displayTitle.UseCompatibleTextRendering = true;
            // 
            // displayImage
            // 
            this.displayImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.displayImage.Location = new System.Drawing.Point(30, 20);
            this.displayImage.Name = "displayImage";
            this.displayImage.Size = new System.Drawing.Size(166, 256);
            this.displayImage.TabIndex = 1;
            this.displayImage.TabStop = false;
            // 
            // displayAuthor
            // 
            this.displayAuthor.AutoSize = true;
            this.displayAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayAuthor.Location = new System.Drawing.Point(46, 325);
            this.displayAuthor.Name = "displayAuthor";
            this.displayAuthor.Size = new System.Drawing.Size(67, 25);
            this.displayAuthor.TabIndex = 2;
            this.displayAuthor.Text = "author";
            this.displayAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // displayPublisher
            // 
            this.displayPublisher.AutoSize = true;
            this.displayPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPublisher.Location = new System.Drawing.Point(568, 161);
            this.displayPublisher.Name = "displayPublisher";
            this.displayPublisher.Size = new System.Drawing.Size(66, 17);
            this.displayPublisher.TabIndex = 3;
            this.displayPublisher.Text = "publisher";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Published by:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Written by:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pages:";
            // 
            // displayPages
            // 
            this.displayPages.AutoSize = true;
            this.displayPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPages.Location = new System.Drawing.Point(318, 184);
            this.displayPages.Name = "displayPages";
            this.displayPages.Size = new System.Drawing.Size(47, 17);
            this.displayPages.TabIndex = 7;
            this.displayPages.Text = "pages";
            // 
            // displayPublicationYear
            // 
            this.displayPublicationYear.AutoSize = true;
            this.displayPublicationYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPublicationYear.Location = new System.Drawing.Point(390, 261);
            this.displayPublicationYear.Name = "displayPublicationYear";
            this.displayPublicationYear.Size = new System.Drawing.Size(36, 17);
            this.displayPublicationYear.TabIndex = 9;
            this.displayPublicationYear.Text = "year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(269, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Publication Year:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(576, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Price:";
            // 
            // displayPrice
            // 
            this.displayPrice.AutoSize = true;
            this.displayPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayPrice.Location = new System.Drawing.Point(644, 312);
            this.displayPrice.Name = "displayPrice";
            this.displayPrice.Size = new System.Drawing.Size(78, 31);
            this.displayPrice.TabIndex = 11;
            this.displayPrice.Text = "price";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(270, 339);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(102, 22);
            this.label.TabIndex = 12;
            this.label.Text = "Categories:";
            // 
            // displayCategories
            // 
            this.displayCategories.AutoSize = true;
            this.displayCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayCategories.Location = new System.Drawing.Point(367, 371);
            this.displayCategories.Name = "displayCategories";
            this.displayCategories.Size = new System.Drawing.Size(72, 16);
            this.displayCategories.TabIndex = 13;
            this.displayCategories.Text = "categories";
            // 
            // ReviewItemBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.displayCategories);
            this.Controls.Add(this.label);
            this.Controls.Add(this.displayPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.displayPublicationYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.displayPages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayPublisher);
            this.Controls.Add(this.displayAuthor);
            this.Controls.Add(this.displayImage);
            this.Controls.Add(this.displayTitle);
            this.Name = "ReviewItemBook";
            ((System.ComponentModel.ISupportInitialize)(this.displayImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayTitle;
        private System.Windows.Forms.PictureBox displayImage;
        private System.Windows.Forms.Label displayAuthor;
        private System.Windows.Forms.Label displayPublisher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label displayPages;
        private System.Windows.Forms.Label displayPublicationYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label displayPrice;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label displayCategories;
    }
}
