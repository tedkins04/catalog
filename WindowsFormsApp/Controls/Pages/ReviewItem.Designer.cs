namespace WindowsFormsApp.Controls.Pages
{
    partial class ReviewItem
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
            this.back = new System.Windows.Forms.Button();
            this.item = new System.Windows.Forms.Panel();
            this.reviewItemBook = new WindowsFormsApp.Controls.Review.ReviewItemBook();
            this.reviewItemMovie = new WindowsFormsApp.Controls.Review.ReviewItemMovie();
            this.item.SuspendLayout();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(4, 4);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(30, 30);
            this.back.TabIndex = 0;
            this.back.Text = "<";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // item
            // 
            this.item.Controls.Add(this.reviewItemBook);
            this.item.Controls.Add(this.reviewItemMovie);
            this.item.Location = new System.Drawing.Point(41, 4);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(813, 525);
            this.item.TabIndex = 1;
            // 
            // reviewItemBook
            // 
            this.reviewItemBook.BackColor = System.Drawing.Color.Silver;
            this.reviewItemBook.Location = new System.Drawing.Point(0, 0);
            this.reviewItemBook.Name = "reviewItemBook";
            this.reviewItemBook.Size = new System.Drawing.Size(813, 525);
            this.reviewItemBook.TabIndex = 0;
            this.reviewItemBook.Visible = false;
            // 
            // reviewItemMovie
            // 
            this.reviewItemMovie.BackColor = System.Drawing.Color.Silver;
            this.reviewItemMovie.Location = new System.Drawing.Point(0, 0);
            this.reviewItemMovie.Name = "reviewItemMovie";
            this.reviewItemMovie.Size = new System.Drawing.Size(813, 525);
            this.reviewItemMovie.TabIndex = 1;
            this.reviewItemMovie.Visible = false;
            // 
            // ReviewItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.item);
            this.Controls.Add(this.back);
            this.Name = "ReviewItem";
            this.Size = new System.Drawing.Size(857, 532);
            this.item.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel item;
        private Review.ReviewItemMovie reviewItemMovie;
        private Review.ReviewItemBook reviewItemBook;
    }
}
