using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using NUnit.Framework;
using Moq;
using ConsolePresentation;
using ConsolePresentation.ModelPresentation;
using Data.Model;
using Data;
using Business.Businesses;
using static NUnitTests.MockDbSet;
using System.Configuration;

namespace NUnitTests.BusinessTests
{
    [TestFixture]
    class BusinessBookTests
    {
        private Mock<DbSet<Actor>> mockActors;
        private Mock<DbSet<Author>> mockAuthors;
        private Mock<DbSet<Book>> mockBooks;
        private Mock<DbSet<Category>> mockCategories;
        private Mock<DbSet<Director>> mockDirectors;
        private Mock<DbSet<Movie>> mockMovies;
        private Mock<DbSet<Publisher>> mockPublishers;

        private Mock<CatalogDbContext> mockDbContext;

        /// <summary>
        /// Does the setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            List<Actor> actors = new List<Actor>()
            {
                new Actor() {Id = 1, FirstName = "firstName", LastName = "lastName"},
                new Actor() {Id = 2, FirstName = "firstName", LastName = "lastName"}
            };

            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, FirstName = "firstName", LastName = "lastName"},
                new Author() { Id = 2, FirstName = "firstName", LastName = "lastName"}
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Title = "title", AuthorId = 1, PublisherId = 1, Pages = 1, PublicationYear = 1234, CategoryIds = "1", Price = 10.00M},
                new Book() { Id = 2, Title = "title", AuthorId = 1, PublisherId = 1, Pages = 1, PublicationYear = 1234, CategoryIds = "1", Price = 10.00M}
            };

            List<Category> categories = new List<Category>()
            {
                new Category() {Id = 1, Name = "Action"},
                new Category() {Id = 2, Name = "Comedy"}
            };

            List<Director> directors = new List<Director>()
            {
                new Director() {Id = 1, FirstName = "firstName", LastName = "lastName"},
                new Director() {Id = 2, FirstName = "firstName", LastName = "lastName"}
            };

            List<Movie> movies = new List<Movie>()
            {
                new Movie() {Id = 1, Title = "title", DirectorId = 1, ActorIds = "1", PublicationYear = 1234, CategoryIds = "1"},
                new Movie() {Id = 2, Title = "title", DirectorId = 1, ActorIds = "1", PublicationYear = 1234, CategoryIds = "1"}
            };

            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher() { Id = 1, Name = "name1" },
                new Publisher() { Id = 2, Name = "name2" },
            };

            mockActors = GetQueryableMockDbSet(actors);

            mockActors.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => actors.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockAuthors = GetQueryableMockDbSet(authors);

            mockAuthors.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => authors.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockBooks = GetQueryableMockDbSet(books);

            mockBooks.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => books.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockCategories = GetQueryableMockDbSet(categories);

            mockCategories.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => categories.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockDirectors = GetQueryableMockDbSet(directors);

            mockDirectors.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => directors.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockMovies = GetQueryableMockDbSet(movies);

            mockMovies.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => movies.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockPublishers = GetQueryableMockDbSet(publishers);

            mockPublishers.Setup(x => x.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => publishers.AsQueryable().FirstOrDefault(n => n.Id == (int)ids[0]));

            mockDbContext = new Mock<CatalogDbContext>();

            mockDbContext.Setup(x => x.Actors).Returns(mockActors.Object);
            mockDbContext.Setup(x => x.Authors).Returns(mockAuthors.Object);
            mockDbContext.Setup(x => x.Books).Returns(mockBooks.Object);
            mockDbContext.Setup(x => x.Categories).Returns(mockCategories.Object);
            mockDbContext.Setup(x => x.Directors).Returns(mockDirectors.Object);
            mockDbContext.Setup(x => x.Movies).Returns(mockMovies.Object);
            mockDbContext.Setup(x => x.Publishers).Returns(mockPublishers.Object);
        }

        [Test, Description("Ensures that when added the book stays in the database")]
        public void Add_New_Book_To_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            Book mockBook = new Book()
            {
                Id = 2,
                Title = "title",
                AuthorId = 1,
                PublisherId = 1,
                Pages = 1,
                PublicationYear = 1234,
                CategoryIds = "1",
                Price = 10.00M
            };

            mockBusinessBook.AddBook(mockBook);

            CatalogDbContext cDbContext = mockBusinessBook.GetCatalogDbContext();

            Assert.Contains(mockBook, cDbContext.Books.ToList(), "Book isn't added.");
        }

        [Test, Description("Ensures that when added a book with value null an error is thrown.")]
        public void Add_Null_Book_To_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            Book mockBook = null;

            Assert.Throws<ArgumentNullException>(() => mockBusinessBook.AddBook(mockBook), "Book with value null was added to the database.");
        }

        [Test, Description("Ensures that a book with the following id and name exists in the database")]
        public void Get_Book_By_Id_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int bookId = 1;

            Book mockBook = mockBusinessBook.GetBook(bookId);

            Assert.AreEqual(bookId, mockBook.Id, "Wrong book found.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Get_Book_By_Id_That_Is_Not_In_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int bookId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessBook.GetBook(bookId));
        }

        [Test, Description("Ensures that a book with the following id will be deleted.")]
        public void Delete_Book_By_Id_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int bookId = 1;

            int oldBookCount = mockBusinessBook.GetCatalogDbContext().Books.Count();

            mockBusinessBook.DeleteBook(bookId);

            int currentBookCount = mockBusinessBook.GetCatalogDbContext().Books.Count();

            Assert.Less(currentBookCount, oldBookCount, "Book was not deleted.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Delete_Book_By_Id_That_Is_Not_In_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int bookId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessBook.DeleteBook(bookId));
        }

        [Test, Description("Ensures that all books will be gotten/fetched")]
        public void Get_All_Books_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int businessBookCount = mockBusinessBook.GetAllBooks().Count();
            int dbBookCount = mockBusinessBook.GetCatalogDbContext().Books.Count();

            Assert.AreEqual(businessBookCount, dbBookCount, "Not all books were gotten/fetched.");
        }

        [Test, Description("Ensures that all books with the chosen category will be fetched.")]
        public void Get_All_Books_By_Category_Id_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int categoryId = 1;
            List<Book> mockBooksWithCategory = mockBusinessBook.GetBooksByCategory(categoryId).ToList();

            CatalogDbContext cDbContext = mockBusinessBook.GetCatalogDbContext();
            List<Book> booksWithCategory = new List<Book>();

            foreach (Book book in cDbContext.Books)
            {
                if (book.CategoryIds.Split().Select(int.Parse).ToList().Contains(categoryId))
                {
                    booksWithCategory.Add(book);
                }
            }

            Assert.AreEqual(booksWithCategory, mockBooksWithCategory, "Not all books with the same category were fetched.");
        }

        [Test, Description("Ensures that when an invalid category is selected an empty list will be returned.")]
        public void Get_Books_By_Invalid_Category_Id()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int categoryId = 10;
            List<Book> mockBooksWithCategory = mockBusinessBook.GetBooksByCategory(categoryId).ToList();

            Assert.IsEmpty(mockBooksWithCategory);
        }

        [Test, Description("Ensures that all books with the chosen key name/title will be fetched.")]
        public void Get_All_Books_By_Title_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            string bookTitle = "title";
            List<Book> mockBooksWithTitle = mockBusinessBook.GetBooksByTitle(bookTitle).ToList();

            CatalogDbContext cDbContext = mockBusinessBook.GetCatalogDbContext();
            List<Book> booksWithTitle = new List<Book>();

            foreach (Book book in cDbContext.Books)
            {
                if (book.Title.ToLower().Contains(bookTitle))
                {
                    booksWithTitle.Add(book);
                }
            }

            Assert.AreEqual(booksWithTitle, mockBooksWithTitle, "Not all books with the same key name/title were fetched.");
        }

        [Test, Description("Ensures that when a missing title is entered an empty list will be returned.")]
        public void Get_Books_By_Missing_Title()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            string bookTitle = "yeet420";
            List<Book> mockBooksWithTitle = mockBusinessBook.GetBooksByTitle(bookTitle).ToList();

            Assert.IsEmpty(mockBooksWithTitle, "There do exist books with that title.");
        }

        [Test, Description("Ensures that all books with the chosen publisher will be fetched.")]
        public void Get_All_Books_By_Publisher_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            string bookPublisher = "name1";
            List<Book> mockBooksWithPublisher = mockBusinessBook.GetBooksByPublisher(bookPublisher).ToList();

            CatalogDbContext cDbContext = mockBusinessBook.GetCatalogDbContext();
            BusinessPublishers textBusinessPublisher = new BusinessPublishers(mockDbContext.Object);
            List<Book> booksWithPublisher = new List<Book>();
            int publisherId = textBusinessPublisher.FindPublisherId(bookPublisher);

            foreach (Book book in cDbContext.Books)
            {
                if (book.PublisherId.Equals(publisherId))
                {
                    booksWithPublisher.Add(book);
                }
            }

            Assert.AreEqual(booksWithPublisher, mockBooksWithPublisher, "Not all books with the same publisher were fetched.");
        }

        [Test, Description("Ensures that when a missing publisher is entered an empty list will be returned.")]
        public void Get_Books_By_Missing_Publisher()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            string bookPublisher = "yeet420";
            List<Book> mockBooksWithTitle = mockBusinessBook.GetBooksByPublisher(bookPublisher).ToList();

            Assert.IsEmpty(mockBooksWithTitle, "There does exist such publisher.");
        }

        [Test, Description("Ensures that all books with the chosen author will be fetched.")]
        public void Get_All_Books_By_Author_Id_From_Database()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int authorId = 1;
            List<Book> mockBooksWithAuthor = mockBusinessBook.GetBooksByAuthorId(authorId).ToList();

            CatalogDbContext cDbContext = mockBusinessBook.GetCatalogDbContext();
            List<Book> booksWithAuthor = new List<Book>();

            foreach (Book book in cDbContext.Books)
            {
                if (book.AuthorId.Equals(authorId))
                {
                    booksWithAuthor.Add(book);
                }
            }

            Assert.AreEqual(booksWithAuthor, mockBooksWithAuthor, "Not all books with the same author were fetched.");
        }

        [Test, Description("Ensures that when an invalid author is selected an empty list will be returned.")]
        public void Get_Books_By_Invalid_Author_Id()
        {
            BusinessBooks mockBusinessBook = new BusinessBooks(mockDbContext.Object);

            int authorId = 10;
            List<Book> mockBooksWithAuthor = mockBusinessBook.GetBooksByAuthorId(authorId).ToList();

            Assert.IsEmpty(mockBooksWithAuthor, "There does exist an author with that id.");
        }
    }
}
