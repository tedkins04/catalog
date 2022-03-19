using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessBooks
    {
        private CatalogDbContext database;

        public BusinessBooks()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessBooks(CatalogDbContext cDbContext)
        {
            database = cDbContext;
        }

        /// <summary>
        /// Returns the database context.
        /// </summary>
        public CatalogDbContext GetCatalogDbContext()
        {
            return database;
        }

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">The book</param>
        public void AddBook(Book book)
        {
            if (book != null)
            {
                database.Books.Add(book);
                database.SaveChanges();
                return;
            }

            throw new ArgumentNullException("Book mustn't be empty/null.");
        }

        /// <summary>
        /// Gets the book from the database by its id.
        /// </summary>
        /// <param name="id">The book's id</param>
        public Book GetBook(int id)
        {
            foreach (Book book in database.Books)
            {
                if (id == book.Id)
                {
                    return book;
                }
            }

            throw new IndexOutOfRangeException("Book with this id does not exist!");
        }

        /// <summary>
        /// Deletes the book from the database by its id.
        /// </summary>
        /// <param name="id">The book's id</param>
        public void DeleteBook(int id)
        {
            foreach (Book book in database.Books)
            {
                if (id == book.Id)
                {
                    database.Books.Remove(book);
                    database.SaveChanges();
                    return;
                }
            }

            throw new IndexOutOfRangeException("Book with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all the books from the database.
        /// </summary>
        public List<Book> GetAllBooks()
        {
            return database.Books.ToList();
        }

        /// <summary>
        /// Gets all the books based on the chosen category id.
        /// </summary>
        /// <param name="categoryId">The category's id</param>
        public List<Book> GetBooksByCategory(int categoryId)
        {
            List<Book> books = new List<Book>();
            foreach (Book book in database.Books)
            {
                //turns the category ids from a string array to integers
                List<int> booksCategory = book.CategoryIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                
                if (booksCategory.Contains(categoryId))
                {
                    books.Add(book);
                }
            }

            return books;
        }

        /// <summary>
        /// Gets all the books that contain the same key name/title.
        /// </summary>
        /// <param name="bookTitle">The book's entered name</param>
        public List<Book> GetBooksByTitle(string bookTitle)
        {
            List<Book> booksWithSameName = new List<Book>();
            foreach (Book book in database.Books)
            {
                if (book.Title.ToLower().Contains(bookTitle.ToLower()))
                {
                    booksWithSameName.Add(book);
                }
            }


            return booksWithSameName;
        }

        /// <summary>
        /// Gets all the books that have been published by the entered publisher.
        /// </summary>
        /// <param name="publisherName">The publisher's name</param>
        public List<Book> GetBooksByPublisher(string publisherName)
        {
            List<Book> publisherBooks = new List<Book>();
            int publisherId = FindPublisherId(publisherName);
            foreach (Book book in database.Books)
            {
                if (book.PublisherId == publisherId)
                {
                    publisherBooks.Add(book);
                }
            }

            return publisherBooks;
        }

        /// <summary>
        /// Finds the publisher's id based on his name.
        /// </summary>
        /// <param name="publisherName">The publisher's name</param>
        private int FindPublisherId(string publisherName)
        {
            foreach (Publisher publisher in database.Publishers)
            {
                if (publisher.Name.ToLower() == publisherName.ToLower())
                {
                    return publisher.Id;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets all the books based on their author's id
        /// </summary>
        /// <param name="authorId">The author's id</param>
        public List<Book> GetBooksByAuthorId(int authorId)
        {
            if (authorId <= 0)
            {
                return new List<Book>();
            }

            List<Book> books = new List<Book>();
            foreach (Book book in database.Books)
            {
                if (book.AuthorId == authorId)
                {
                    books.Add(book);
                }
            }

            return books;
        }
    }
}
