using System.Drawing;
using System.Windows.Forms;
using Data.Model;
using WindowsFormsApp.Controls.Display;
using WindowsFormsApp.Controls.Pages;
using WindowsFormsApp.Resouces;

namespace WindowsFormsApp.Controls
{
    public partial class ListItems : UserControl
    {
        private int itemHeight;
        private ImageLoader imageLoader;

        public ListItems()
        {
            InitializeComponent();

            this.BackColor = Color.DarkGray;
            this.itemHeight = 60;
            this.AutoScroll = true;
        }

        /// <summary>
        /// Adds information for book
        /// </summary>
        /// <param name="book">The book</param>
        /// <param name="author">The author</param>
        /// <param name="publisher">The publisher</param>
        /// <param name="categories">The categories</param>
        public void AddItem(Book book, Author author, Publisher publisher, Category[] categories)
        {
            DisplayItemBook displayItem = new DisplayItemBook(book, author, publisher, categories);
            displayItem.Location = new Point(0, (itemHeight + 2) * Controls.Count);
            displayItem.Image = imageLoader.GetBookImage(book.Id);
            displayItem.RefreshDisplayInfo();
            Controls.Add(displayItem);

            UpdateControlWidth();
        }

        /// <summary>
        /// Adds information for movie
        /// </summary>
        /// <param name="movie">The movie</param>
        /// <param name="director">The directors</param>
        /// <param name="actors">The actors</param>
        /// <param name="categories">The categories</param>
        public void AddItem(Movie movie, Director director, Actor[] actors, Category[] categories)
        {
            DisplayItemMovie displayItem = new DisplayItemMovie(movie, director, actors, categories);
            displayItem.Location = new Point(0, (itemHeight + 2) * Controls.Count);
            displayItem.Image = imageLoader.GetMovieImage(movie.Id);
            displayItem.RefreshDisplayInfo();
            Controls.Add(displayItem);

            UpdateControlWidth();
        }

        /// <summary>
        /// Removes all information for books and movies
        /// </summary>
        public void Clear() => Controls.Clear();

        /// <summary>
        /// Updates all controls`s width
        /// </summary>
        private void UpdateControlWidth()
        {
            int width = this.Width - 2 - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0);
            
            foreach(Control control in Controls)
            {
                control.Width = width;
            }
        }

        /// <summary>
        /// Sets or returns image of elements
        /// </summary>
        /// <param name="reviewItem"></param>
        public void SetReviewItem(ReviewItem reviewItem)
        {
            foreach (Control control in Controls)
            {
                ((DisplayItemBase)control).ReviewItem = reviewItem;
            }
        }

        /// <summary>
        /// Initializes the image loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItems_Load(object sender, System.EventArgs e)
        {
            imageLoader = new ImageLoader();
            imageLoader.LoadImages();
        }
    }
}
