using System.Windows.Forms;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Pages
{
    public partial class ReviewItem : UserControl
    {
        private Form1 form;
        private bool hasItem;

        public ReviewItem() : base()
        {
            InitializeComponent();

            this.hasItem = false;
            this.reviewItemBook.Hide();
            this.reviewItemMovie.Hide();
        }

        /// <summary>
        /// Sets the current element
        /// </summary>
        /// <param name="displayItem"></param>
        public void SetDisplayItem(DisplayItemBase displayItem)
        {
            this.hasItem = true;
            if(displayItem is DisplayItemBook)
            {
                reviewItemBook.UpdateDisplayInformation(displayItem);
                reviewItemMovie.Hide();
                reviewItemBook.Show();
                reviewItemBook.BringToFront();
            }
            else if(displayItem is DisplayItemMovie)
            {
                reviewItemMovie.UpdateDisplayInformation(displayItem);
                reviewItemBook.Hide();
                reviewItemMovie.Show();
                reviewItemMovie.BringToFront();
            }
            
            form.UpdateView();
        }

        /// <summary>
        /// Sets the current form
        /// </summary>
        /// <param name="form"></param>
        public void SetForm(Form1 form) => this.form = form;

        /// <summary>
        /// Returns whether there is an item
        /// </summary>
        public bool HasItem { get => hasItem; }

        /// <summary>
        /// Clears the item and returns to search item page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, System.EventArgs e)
        {
            this.hasItem = false;
            form.UpdateView();
        }
    }
}
