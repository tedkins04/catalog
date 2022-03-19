using System.Linq;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Review
{
    public partial class ReviewItemBook : ReviewItemBase
    {

        public ReviewItemBook() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates book`s information
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateDisplayInformation(DisplayItemBase item)
        {
            DisplayItemBook displayItem = (DisplayItemBook)item;

            if(displayItem != null)
            {
                this.displayTitle.Text = displayItem.Book.Title;
                this.displayImage.BackgroundImage = displayItem.Image;
                this.displayAuthor.Text = displayItem.Author.FirstName + " " + displayItem.Author.LastName;
                this.displayPages.Text = displayItem.Book.Pages.ToString();
                this.displayPublicationYear.Text = displayItem.Book.PublicationYear.ToString();
                this.displayPublisher.Text = displayItem.Publisher.Name;
                this.displayCategories.Text = string.Join("\n", displayItem.Categories.Select(c => c.Name).ToArray());
                this.displayPrice.Text = displayItem.Book.Price.ToString();
            }
        }
    }
}
