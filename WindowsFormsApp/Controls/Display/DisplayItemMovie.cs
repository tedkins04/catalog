using Data.Model;
using WindowsFormsApp.Controls.Display;

namespace WindowsFormsApp.Controls
{
    /// <summary>
    /// Class for storing all the data for movie
    /// </summary>
    public partial class DisplayItemMovie : DisplayItemBase
    {
        private Movie movie;
        private Director director;
        private Actor[] actors;
        private Category[] categories;

        public DisplayItemMovie(Movie movie, Director director, Actor[] actors, Category[] categories) : base()
        {
            InitializeComponent();

            this.movie = movie;
            this.director = director;
            this.actors = actors;
            this.categories = categories;
        }
        
        /// <summary>
        /// Refreshing display information for current book
        /// </summary>
        public override void RefreshDisplayInfo()
        {
            this.displayTitle.Text = movie.Title;
            this.displayDirector.Text = director.FirstName + " " + director.LastName;
            this.pictureBox1.BackgroundImage = this.Image;
        }

        /// <summary>
        /// Returns current movie
        /// </summary>
        public Movie Movie { get => movie; }

        /// <summary>
        /// Returns current director
        /// </summary>
        public Director Director { get => director; }

        /// <summary>
        /// Returns current actors
        /// </summary>
        public Actor[] Actors { get => actors; }

        /// <summary>
        /// Returns current categories
        /// </summary>
        public Category[] Categories { get => categories; }
    }
}
