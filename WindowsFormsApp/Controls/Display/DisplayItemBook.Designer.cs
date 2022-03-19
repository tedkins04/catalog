namespace WindowsFormsApp.Controls
{
    partial class DisplayItemBook
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.displayAuthor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // displayTitle
            // 
            this.displayTitle.AutoSize = true;
            this.displayTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTitle.Location = new System.Drawing.Point(89, 13);
            this.displayTitle.Name = "displayTitle";
            this.displayTitle.Size = new System.Drawing.Size(35, 17);
            this.displayTitle.TabIndex = 0;
            this.displayTitle.Text = "title";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 54);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // displayAuthor
            // 
            this.displayAuthor.AutoSize = true;
            this.displayAuthor.Location = new System.Drawing.Point(109, 30);
            this.displayAuthor.Name = "displayAuthor";
            this.displayAuthor.Size = new System.Drawing.Size(37, 13);
            this.displayAuthor.TabIndex = 2;
            this.displayAuthor.Text = "author";
            // 
            // DisplayItemBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.displayAuthor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.displayTitle);
            this.Name = "DisplayItemBook";
            this.Size = new System.Drawing.Size(660, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label displayAuthor;
    }
}
