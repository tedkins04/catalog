using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Business.Businesses;
using Data.Model;

namespace WindowsFormsApp.Controls.Pages
{
    public partial class SearchItem : UserControl
    {
        private BusinessBooks businessBooks;
        private BusinessAuthors businessAuthors;
        private BusinessCategories businessCategories;
        private BusinessPublishers businessPublishers;
        private BusinessDirectors businessDirectors;
        private BusinessMovies businessMovies;
        private BusinessActors businessActors;

        private float minPrice;
        private float maxPrice;

        private ReviewItem reviewItem;

        public SearchItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks elements values by filters
        /// </summary>
        /// <param name="price">The price of item or -1.0 if it doesn't have</param>
        /// <param name="categories">The categories` ids</param>
        /// <param name="texts">The item`s keywords</param>
        /// <returns></returns>
        private bool CheckFilters(float price, int[] categories, string[] texts)
        {
            if (useOtherFillters.Checked)
            {
                //Checks if item has price
                if (price > 0.0)
                {
                    //Checks if item`s value is outside of the range
                    if (price < minPrice || price > maxPrice)
                    {
                        return false;
                    }
                }
                
                bool contain = false;
                foreach (object checkedId in selectCategories.CheckedIndices)
                {
                    //Checks if some of item`s categories contains in the selected categories
                    if (categories.Contains(int.Parse(checkedId.ToString()) + 1))
                    {
                        contain = true;
                        break;
                    }
                }
                if (!contain)
                {
                    return false;
                }
            }

            //Checkes whether there are keywords
            if (texts != null)
            {
                bool containText = false;
                foreach (string text in texts)
                {
                    //Checks if some of item`s keywords contains in keywords from the search fueld
                    if (text.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        containText = true;
                        break;
                    }
                }
                if (!containText)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Adds all items by filters
        /// </summary>
        private void UpdateItems()
        {
            displayItems.Clear();

            if (showBooks.Checked)
            {
                List<Book> books = businessBooks.GetAllBooks();

                if (orderByAsc.Checked)
                {
                    books.Sort((i, j) => string.Compare(i.Title, j.Title));
                }
                else if(orderByDesc.Checked)
                {
                    books.Sort((i, j) => string.Compare(j.Title, i.Title));
                }

                foreach (Book book in books)
                {
                    Author author = businessAuthors.GetAuthor(book.AuthorId);
                    Publisher publisher = businessPublishers.GetPublisher(book.PublisherId);
                    Category[] categories = book.CategoryIds.Split(',').Select(i => businessCategories.GetCategory(int.Parse(i))).ToArray();

                    List<string> texts = new List<string>();

                    if (searchInEverything.Checked)
                    {
                        texts.AddRange(categories.Select(i => i.Name).ToList());
                        texts.Add(author.FirstName + " " + author.LastName);
                        texts.Add(publisher.Name);
                    }

                    texts.Add(book.Title);

                    if (CheckFilters((float)book.Price, categories.Select(i => i.Id).ToArray(), texts.ToArray()))
                    {
                        displayItems.AddItem(book, author, publisher, categories);
                    }
                }
            }

            if (showMovies.Checked)
            {
                List<Movie> movies = businessMovies.GetAllMovies();

                if (orderByAsc.Checked)
                {
                    movies.Sort((i, j) => string.Compare(i.Title, j.Title));
                }
                else if (orderByDesc.Checked)
                {
                    movies.Sort((i, j) => string.Compare(j.Title, i.Title));
                }

                foreach (Movie movie in movies)
                {
                    Director director = businessDirectors.GetDirector(movie.DirectorId);
                    Actor[] actors = movie.ActorIds.Split(',').Select(i => businessActors.GetActor(int.Parse(i))).ToArray();
                    Category[] categories = movie.CategoryIds.Split(',').Select(i => businessCategories.GetCategory(int.Parse(i))).ToArray();

                    List<string> texts = new List<string>();

                    if (searchInEverything.Checked)
                    {
                        texts.AddRange(categories.Select(i => i.Name).ToList());
                        texts.AddRange(actors.Select(i => i.FirstName + " " + i.LastName).ToArray());
                        texts.Add(director.FirstName + " " + director.LastName);
                    }
                    texts.Add(movie.Title);

                    if (CheckFilters(-1.0f, categories.Select(i => i.Id).ToArray(), texts.ToArray()))
                    {
                        displayItems.AddItem(movie, director, actors, categories);
                    }
                }
            }

            displayItems.SetReviewItem(reviewItem);
        }

        /// <summary>
        /// Gets the largest price
        /// </summary>
        /// <returns></returns>
        private float GetMaxPrice()
        {
            float price = 0.0f;

            foreach (Book book in businessBooks.GetAllBooks())
            {
                price = Math.Max(price, (float)book.Price);
            }

            return price;
        }

        /// <summary>
        /// Gets the smallest price
        /// </summary>
        /// <returns></returns>
        private float GetMinPrice()
        {
            float price = GetMaxPrice();

            foreach (Book book in businessBooks.GetAllBooks())
            {
                price = Math.Min(price, (float)book.Price);
            }

            return price;
        }

        /// <summary>
        /// Updates keywords for search field autocomplete
        /// </summary>
        private void SearchAutoComplete()
        {
            searchBox.AutoCompleteCustomSource.Clear();

            foreach (string title in businessBooks.GetAllBooks().Select(i => i.Title).ToArray())
            {
                searchBox.AutoCompleteCustomSource.Add(title);
            }

            foreach (string title in businessMovies.GetAllMovies().Select(i => i.Title).ToArray())
            {
                searchBox.AutoCompleteCustomSource.Add(title);
            }

            if (searchInEverything.Checked)
            {
                foreach (string name in businessDirectors.GetAllDirectors().Select(i => (i.FirstName + " " + i.LastName)).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }

                foreach (string name in businessAuthors.GetAllAuthors().Select(i => (i.FirstName + " " + i.LastName)).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }

                foreach (string name in businessActors.GetAllActors().Select(i => (i.FirstName + " " + i.LastName)).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }

                foreach (string name in businessPublishers.GetAllPublishers().Select(i => i.Name).ToArray())
                {
                    searchBox.AutoCompleteCustomSource.Add(name);
                }
            }
        }

        /// <summary>
        /// Resets all filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearFilters_Click(object sender, EventArgs e) => ResetFilters();

        /// <summary>
        /// Applies filters to all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applyFilters_Click(object sender, EventArgs e)
        {
            //Makes validation of the text from fueld of minimum price
            if ((!float.TryParse(enterMinPrice.Text, out minPrice) || minPrice < GetMinPrice()) && enterMinPrice.Text.Length > 0)
            {
                enterMinPrice.Text = GetMinPrice().ToString();
            }

            //Makes validation of the text from fueld of maximum price
            if ((!float.TryParse(enterMaxPrice.Text, out maxPrice) || maxPrice > GetMaxPrice()) && enterMaxPrice.Text.Length > 0)
            {
                enterMaxPrice.Text = GetMaxPrice().ToString();
            }

            UpdateItems();
        }

        /// <summary>
        /// Adds all keywords in search field autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchInEverything_CheckedChanged(object sender, EventArgs e) => SearchAutoComplete();

        /// <summary>
        /// Adds all keywords in search field autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchInTitles_CheckedChanged(object sender, EventArgs e) => SearchAutoComplete();
        
        /// <summary>
        /// Selects or unselects all categories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            for (int a = 0; a < selectCategories.Items.Count; a++)
            {
                selectCategories.SetItemChecked(a, selectAllCategories.Checked);
            }
        }

        /// <summary>
        /// Activation or deactivation of other fields except the field for search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void useOtherFillters_CheckedChanged(object sender, EventArgs e)
        {
            priceGroup.Enabled = useOtherFillters.Checked;
            typeGroup.Enabled = useOtherFillters.Checked;
            categoryGroup.Enabled = useOtherFillters.Checked;
        }

        /// <summary>
        /// Changes all filters`s values to default
        /// </summary>
        private void ResetFilters()
        {
            clearFilters.Enabled = false;

            searchBox.Text = "";
            searchInEverything.Checked = true;
            searchInTitles.Checked = false;
            useOtherFillters.Checked = true;
            enterMinPrice.Text = GetMinPrice().ToString();
            enterMaxPrice.Text = GetMaxPrice().ToString();

            orderByAsc.Checked = true;
            orderByDesc.Checked = false;

            SearchAutoComplete();

            clearFilters.Enabled = true;
        }

        /// <summary>
        /// Returns the x position of display items
        /// </summary>
        public int DisplayItemsX { get => displayItems.Location.X; }

        /// <summary>
        /// Sets ReviewItem instance of the control
        /// </summary>
        /// <param name="reviewItem"></param>
        public void SetReviewItem(ReviewItem reviewItem)
        {
            this.reviewItem = reviewItem;
            displayItems.SetReviewItem(reviewItem);
        }

        /// <summary>
        /// Initializes the values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayItems_Load(object sender, EventArgs e)
        {
            this.businessActors = new BusinessActors();
            this.businessAuthors = new BusinessAuthors();
            this.businessBooks = new BusinessBooks();
            this.businessCategories = new BusinessCategories();
            this.businessDirectors = new BusinessDirectors();
            this.businessMovies = new BusinessMovies();
            this.businessPublishers = new BusinessPublishers();

            foreach (string name in businessCategories.GetAllCategories().Select(i => i.Name).ToArray())
            {
                selectCategories.Items.Add(name);
            }

            for (int a = 0; a < selectCategories.Items.Count; a++)
            {
                selectCategories.SetItemChecked(a, true);
            }

            ResetFilters();
            UpdateItems();
        }
    }
}
