namespace WindowsFormsApp.Controls
{
    partial class DisplayItemMovie
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
            this.displayDirector = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.displayTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // displayDirector
            // 
            this.displayDirector.AutoSize = true;
            this.displayDirector.Location = new System.Drawing.Point(108, 29);
            this.displayDirector.Name = "displayDirector";
            this.displayDirector.Size = new System.Drawing.Size(42, 13);
            this.displayDirector.TabIndex = 5;
            this.displayDirector.Text = "director";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 54);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // displayTitle
            // 
            this.displayTitle.AutoSize = true;
            this.displayTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayTitle.Location = new System.Drawing.Point(88, 12);
            this.displayTitle.Name = "displayTitle";
            this.displayTitle.Size = new System.Drawing.Size(35, 17);
            this.displayTitle.TabIndex = 3;
            this.displayTitle.Text = "title";
            // 
            // DisplayItemMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.displayDirector);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.displayTitle);
            this.Name = "DisplayItemMovie";
            this.Size = new System.Drawing.Size(660, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayDirector;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label displayTitle;
    }
}
