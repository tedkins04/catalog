using System.Linq;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls.Review
{
    public partial class ReviewItemMovie : ReviewItemBase
    {
        public ReviewItemMovie() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates movie`s information
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateDisplayInformation(DisplayItemBase item)
        {
            DisplayItemMovie displayItem = (DisplayItemMovie)item;

            if (displayItem != null)
            {
                this.displayTitle.Text = displayItem.Movie.Title;
                this.displayImage.BackgroundImage = displayItem.Image;
                this.displayActors.Text = string.Join("\n", displayItem.Actors.Select(c => c.FirstName + " " + c.LastName).ToArray());
                this.displayCategories.Text = string.Join("\n", displayItem.Categories.Select(c => c.Name).ToArray());
                this.displayDirector.Text = displayItem.Director.FirstName + " " + displayItem.Director.LastName;
                this.displayPublicationYear.Text = displayItem.Movie.PublicationYear.ToString();
            }
        }
    }
}
