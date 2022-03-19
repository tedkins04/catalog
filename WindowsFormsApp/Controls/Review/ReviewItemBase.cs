using System.Windows.Forms;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Review
{
    public partial class ReviewItemBase : UserControl
    {
        public ReviewItemBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates display information
        /// </summary>
        public virtual void UpdateDisplayInformation(DisplayItemBase displayItem) { }
    }
}
