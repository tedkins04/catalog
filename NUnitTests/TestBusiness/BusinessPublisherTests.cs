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
    class BusinessPublisherTests
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

        [Test, Description("Ensures that when added the publisher stays in the database")]
        public void Add_New_Publisher_To_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            Publisher mockPublisher = new Publisher()
            {
                Id = 3,
                Name = "name3",
            };

            mockBusinessPublisher.AddPublisher(mockPublisher);

            CatalogDbContext cDbContext = mockBusinessPublisher.GetCatalogDbContext();

            Assert.Contains(mockPublisher, cDbContext.Publishers.ToList(), "Publisher isn't added.");
        }

        [Test, Description("Ensures that when added a publisher with value null an error is thrown.")]
        public void Add_Null_Publisher_To_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            Publisher mockPublisher = null;

            Assert.Throws<ArgumentNullException>(() => mockBusinessPublisher.AddPublisher(mockPublisher), "Publisher with value null was added to the database.");
        }

        [Test, Description("Ensures that a publisher with the following id and name exists in the database")]
        public void Get_Publisher_By_Id_From_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            int publisherId = 1;

            Publisher mockPublisher = mockBusinessPublisher.GetPublisher(publisherId);

            Assert.AreEqual(publisherId, mockPublisher.Id, "Wrong publisher found.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Get_Publisher_By_Id_That_Is_Not_In_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            int publisherId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessPublisher.GetPublisher(publisherId));
        }

        [Test, Description("Ensures that a publisher with the following id will be deleted.")]
        public void Delete_Publisher_By_Id_From_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            int publisherId = 1;

            int oldPublisherCount = mockBusinessPublisher.GetCatalogDbContext().Publishers.Count();

            mockBusinessPublisher.DeletePublisher(publisherId);

            int currentPublisherCount = mockBusinessPublisher.GetCatalogDbContext().Publishers.Count();

            Assert.Less(currentPublisherCount, oldPublisherCount, "Publisher was not deleted.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Delete_Publisher_By_Id_That_Is_Not_In_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            int publisherId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessPublisher.DeletePublisher(publisherId));
        }

        [Test, Description("Ensures that all publishers will be gotten/fetched")]
        public void Get_All_Publishers_From_Database()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            int businessPublisherCount = mockBusinessPublisher.GetAllPublishers().Count();
            int dbPublisherCount = mockBusinessPublisher.GetCatalogDbContext().Publishers.Count();

            Assert.AreEqual(businessPublisherCount, dbPublisherCount, "Not all publishers were gotten/fetched.");
        }

        [Test, Description("Ensures that when the publisher's name is entered its id will be fetched.")]
        public void Get_Publisher_Id_By_Name()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            string publisherName = "name1";
            int mockPublisherId = mockBusinessPublisher.FindPublisherId(publisherName);

            CatalogDbContext cDbContext = mockBusinessPublisher.GetCatalogDbContext();
            List<Publisher> allPublishers = cDbContext.Publishers.ToList();

            List<int> publisherIds = new List<int>();
            foreach (Publisher publisher in allPublishers)
            {
                publisherIds.Add(publisher.Id);
            }

            Assert.Contains(mockPublisherId, publisherIds, "The publisher does not exist.");
        }

        [Test, Description("Ensures that when a missing publisher's name is entered an invalid id will be returned.")]
        public void Get_Invalid_Publisher_Id_By_Missing_Name()
        {
            BusinessPublishers mockBusinessPublisher = new BusinessPublishers(mockDbContext.Object);

            string publisherName = "yeet420";

            Assert.AreEqual(-1, mockBusinessPublisher.FindPublisherId(publisherName), "The publisher does exist.");
        }
    }
}
