using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public static int controlsPadding = 12;

        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        /// <summary>
        /// Updates the shown information
        /// </summary>
        public void UpdateView()
        {
            if (reviewItem1.HasItem)
            {
                searchItem1.Hide();

                reviewItem1.Show();
                reviewItem1.BringToFront();
            }
            else
            {
                reviewItem1.Hide();

                searchItem1.Show();
                searchItem1.BringToFront();
            }
        }

        /// <summary>
        /// Sets callback for controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            searchItem1.SetReviewItem(reviewItem1);
            reviewItem1.SetForm(this);

            UpdateView();
        }
    }
}
