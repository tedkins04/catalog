using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp.Controls.Pages;

namespace WindowsFormsApp.Controls.Display
{
    /// <summary>
    /// Base class for displays book or movie info in ListItems
    /// </summary>
    public partial class DisplayItemBase : UserControl
    {
        private Color defaultBackColor;
        private Color mouseOverBackColor;
        private Image image;
        private ReviewItem reviewItem;

        public DisplayItemBase()
        {
            InitializeComponent();

            this.defaultBackColor = Color.LightGray;
            this.mouseOverBackColor = Color.DarkGray;
        }

        /// <summary>
        /// Sets or returns image of elements
        /// </summary>
        public Image Image { get => image; set => image = value; }

        /// <summary>
        /// Sets ReviewItem instance of the control
        /// </summary>
        public ReviewItem ReviewItem { set => this.reviewItem = value; }
        
        /// <summary>
        /// Refreshs display information for current book or movie
        /// </summary>
        public virtual void RefreshDisplayInfo() { }

        /// <summary>
        /// Updates the background color when the mouse comes out of control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayItemBase_MouseLeave(object sender, System.EventArgs e) => this.BackColor = defaultBackColor;

        /// <summary>
        /// Updates background color when mouse enter the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayItemBase_MouseEnter(object sender, System.EventArgs e) => this.BackColor = mouseOverBackColor;

        /// <summary>
        /// Changs current page to review information for book or movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayItemBase_MouseDoubleClick(object sender, MouseEventArgs e) => reviewItem.SetDisplayItem(this);
    }
}
