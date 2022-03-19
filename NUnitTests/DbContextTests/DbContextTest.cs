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

namespace NUnitTests.DbContextTests
{
    [TestFixture]
    class DbContextTest
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

        //Actor database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Actor_Db_Context_Without_Mocked_Context()
        {
            BusinessActors businessActor = new BusinessActors();

            Assert.Catch<InvalidOperationException>(() => businessActor.DeleteActor(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Actor_Db_Context_With_Mocked_Context()
        {
            BusinessActors businessActor = new BusinessActors(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessActor.DeleteActor(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Actor_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessActors businessActor = new BusinessActors(mockDbContext.Object);

            CatalogDbContext cDbContext = businessActor.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }

        //Author database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Author_Db_Context_Without_Mocked_Context()
        {
            BusinessAuthors businessAuthor = new BusinessAuthors();

            Assert.Catch<InvalidOperationException>(() => businessAuthor.DeleteAuthor(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Author_Db_Context_With_Mocked_Context()
        {
            BusinessAuthors businessAuthor = new BusinessAuthors(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessAuthor.DeleteAuthor(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Author_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessAuthors businessAuthor = new BusinessAuthors(mockDbContext.Object);

            CatalogDbContext cDbContext = businessAuthor.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }

        //Book database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Book_Db_Context_Without_Mocked_Context()
        {
            BusinessBooks businessBook = new BusinessBooks();

            Assert.Catch<InvalidOperationException>(() => businessBook.DeleteBook(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Book_Db_Context_With_Mocked_Context()
        {
            BusinessBooks businessBook = new BusinessBooks(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessBook.DeleteBook(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Book_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessBooks businessBook = new BusinessBooks(mockDbContext.Object);

            CatalogDbContext cDbContext = businessBook.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }

        //Category database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Category_Db_Context_Without_Mocked_Context()
        {
            BusinessCategories businessCategory = new BusinessCategories();

            Assert.Catch<InvalidOperationException>(() => businessCategory.DeleteCategory(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Category_Db_Context_With_Mocked_Context()
        {
            BusinessCategories businessCategory = new BusinessCategories(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessCategory.DeleteCategory(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Category_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessCategories businessCategory = new BusinessCategories(mockDbContext.Object);

            CatalogDbContext cDbContext = businessCategory.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }

        //Director database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Director_Db_Context_Without_Mocked_Context()
        {
            BusinessDirectors businessDirector = new BusinessDirectors();

            Assert.Catch<InvalidOperationException>(() => businessDirector.DeleteDirector(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Director_Db_Context_With_Mocked_Context()
        {
            BusinessDirectors businessDirector = new BusinessDirectors(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessDirector.DeleteDirector(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Director_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessDirectors businessDirector = new BusinessDirectors(mockDbContext.Object);

            CatalogDbContext cDbContext = businessDirector.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }

        //Movie database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Movie_Db_Context_Without_Mocked_Context()
        {
            BusinessMovies businessMovie = new BusinessMovies();

            Assert.Catch<InvalidOperationException>(() => businessMovie.DeleteMovie(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Movie_Db_Context_With_Mocked_Context()
        {
            BusinessMovies businessMovie = new BusinessMovies(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessMovie.DeleteMovie(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Movie_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessMovies businessMovie = new BusinessMovies(mockDbContext.Object);

            CatalogDbContext cDbContext = businessMovie.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }

        //Publisher database context tests.
        [Test, Description("If we don't use the mocked dbcontext's object it won't work properly and won't find the connection string.")]
        public void Test_Publisher_Db_Context_Without_Mocked_Context()
        {
            BusinessPublishers businessPublisher = new BusinessPublishers();

            Assert.Catch<InvalidOperationException>(() => businessPublisher.DeletePublisher(1), "There does exist such dbContext.");
        }

        [Test, Description("If we use the mocked dbcontext's object it will work properly.")]
        public void Test_Publisher_Db_Context_With_Mocked_Context()
        {
            BusinessPublishers businessPublisher = new BusinessPublishers(mockDbContext.Object);

            Assert.DoesNotThrow(() => businessPublisher.DeletePublisher(1), "There doesn't exist such dbContext.");
        }

        [Test, Description("Ensures that the GetCatalogDbContext method returns the mocked database's object.")]
        public void Test_Publisher_Db_Context_With_GetCatalogDb_Method()
        {
            BusinessPublishers businessPublisher = new BusinessPublishers(mockDbContext.Object);

            CatalogDbContext cDbContext = businessPublisher.GetCatalogDbContext();

            Assert.AreEqual(cDbContext, mockDbContext.Object, "Wrong database context.");
        }
    }
}
