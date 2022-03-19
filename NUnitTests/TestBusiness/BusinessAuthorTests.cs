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
    class BusinessAuthorTests
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

        [Test, Description("Ensures that when added the author stays in the database")]
        public void Add_New_Author_To_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            Author mockAuthor = new Author()
            {
                Id = 3,
                FirstName = "firstName",
                LastName = "lastName"
            };

            mockBusinessAuthor.AddAuthor(mockAuthor);

            CatalogDbContext cDbContext = mockBusinessAuthor.GetCatalogDbContext();

            Assert.Contains(mockAuthor, cDbContext.Authors.ToList(), "Author isn't added.");
        }

        [Test, Description("Ensures that when added an author with value null an exception is thrown.")]
        public void Add_Null_Author_To_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            Author mockAuthor = null;

            Assert.Throws<ArgumentNullException>(() => mockBusinessAuthor.AddAuthor(mockAuthor), "Author with value null was added to the database.");
        }

        [Test, Description("Ensures that an author with the following id and name exists in the database")]
        public void Get_Author_By_Id_From_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            int authorId = 1;

            Author mockAuthor = mockBusinessAuthor.GetAuthor(authorId);

            Assert.AreEqual(authorId, mockAuthor.Id, "Wrong author found.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Get_Author_By_Id_That_Is_Not_In_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            int authorId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessAuthor.GetAuthor(authorId));
        }

        [Test, Description("Ensures that an author with the following id will be deleted.")]
        public void Delete_Author_By_Id_From_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            int authorId = 1;

            int oldAuthorCount = mockBusinessAuthor.GetCatalogDbContext().Authors.Count();

            mockBusinessAuthor.DeleteAuthor(authorId);

            int currentAuthorCount = mockBusinessAuthor.GetCatalogDbContext().Authors.Count();

            Assert.Less(currentAuthorCount, oldAuthorCount, "Author was not deleted.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Delete_Author_By_Id_That_Is_Not_In_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            int authorId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessAuthor.DeleteAuthor(authorId));
        }

        [Test, Description("Ensures that all authors will be gotten/fetched")]
        public void Get_All_Authors_From_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            int businessAuthorCount = mockBusinessAuthor.GetAllAuthors().Count();
            int dbAuthorCount = mockBusinessAuthor.GetCatalogDbContext().Authors.Count();

            Assert.AreEqual(businessAuthorCount, dbAuthorCount, "Not all authors were gotten/fetched.");
        }

        [Test, Description("Ensures that when entered both names the author's id will be fetched.")]
        public void Get_Author_By_First_And_Last_Name()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            string authorFirstName = "firstName";
            string authorLastName = "lastName";

            int authorId = mockBusinessAuthor.FindAuthorId(authorFirstName, authorLastName);

            CatalogDbContext cDbContext = mockBusinessAuthor.GetCatalogDbContext();

            List<Author> allAuthors = cDbContext.Authors.ToList();
            List<int> authorIds = new List<int>();

            foreach(Author author in allAuthors)
            {
                authorIds.Add(author.Id);
            }


            Assert.Contains(authorId, authorIds, "The author doesn't exist.");
        }

        [Test, Description("Ensures that when entered invalid names an exception will be thrown.")]
        public void Get_Author_Id_By_Names_That_Do_Not_Exist_In_The_Database()
        {
            BusinessAuthors mockBusinessAuthor = new BusinessAuthors(mockDbContext.Object);

            string authorFirstName = "lastName";
            string authorLastName = "firstName";
          
            Assert.Catch<InvalidOperationException>(() => mockBusinessAuthor.FindAuthorId(authorFirstName, authorLastName));
        }
    }
}
