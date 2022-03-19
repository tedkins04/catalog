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
    class BusinessDirectorTests
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

        [Test, Description("Ensures that when added the director stays in the database")]
        public void Add_New_Director_To_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            Director mockDirector = new Director()
            {
                Id = 3,
                FirstName = "firstName",
                LastName = "lastName"
            };

            mockBusinessDirector.AddDirector(mockDirector);

            CatalogDbContext cDbContext = mockBusinessDirector.GetCatalogDbContext();

            Assert.Contains(mockDirector, cDbContext.Directors.ToList(), "Director isn't added.");
        }

        [Test, Description("Ensures that when added a director with value null an error is thrown.")]
        public void Add_Null_Director_To_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            Director mockDirector = null;

            Assert.Throws<ArgumentNullException>(() => mockBusinessDirector.AddDirector(mockDirector), "Director with value null was added to the database.");
        }

        [Test, Description("Ensures that a director with the following id and name exists in the database")]
        public void Get_Director_By_Id_From_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            int directorId = 1;

            Director mockDirector = mockBusinessDirector.GetDirector(directorId);

            Assert.AreEqual(directorId, mockDirector.Id, "Wrong director found.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Get_Director_By_Id_That_Is_Not_In_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            int directorId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessDirector.GetDirector(directorId));
        }

        [Test, Description("Ensures that a director with the following id will be deleted.")]
        public void Delete_Director_By_Id_From_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            int directorId = 1;

            int oldDirectorCount = mockBusinessDirector.GetCatalogDbContext().Directors.Count();

            mockBusinessDirector.DeleteDirector(directorId);

            int currentDirectorCount = mockBusinessDirector.GetCatalogDbContext().Directors.Count();

            Assert.Less(currentDirectorCount, oldDirectorCount, "Director was not deleted.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Delete_Director_By_Id_That_Is_Not_In_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            int directorId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessDirector.DeleteDirector(directorId));
        }

        [Test, Description("Ensures that all directors will be gotten/fetched")]
        public void Get_All_Directors_From_Database()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            int businessDirectorCount = mockBusinessDirector.GetAllDirectors().Count();
            int dbDirectorCount = mockBusinessDirector.GetCatalogDbContext().Directors.Count();

            Assert.AreEqual(businessDirectorCount, dbDirectorCount, "Not all Directors were gotten/fetched.");
        }

        [Test, Description("Ensures that when the director's name is entered its id will be fetched.")]
        public void Get_Director_Id_By_Both_Names()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            string directorBothNames = "firstName" + " " + "lastName";

            string[] directorBothNamesArray = directorBothNames.Split().ToArray();
            string directorFirstName = directorBothNamesArray[0];
            string directorLastName = directorBothNamesArray[1];

            List<int> mockDirectorIds = mockBusinessDirector.FindDirectorId(directorBothNames);

            CatalogDbContext cDbContext = mockBusinessDirector.GetCatalogDbContext();
            List<Director> allDirectors = cDbContext.Directors.ToList();

            List<int> directorIds = new List<int>();
            foreach (Director director in allDirectors)
            {
                if(directorFirstName == director.FirstName && directorLastName == director.LastName)
                {
                    directorIds.Add(director.Id);
                }
                
            }

            Assert.AreEqual(mockDirectorIds, directorIds, "There are missing directors.");
        }

        [Test, Description("Ensures that when the director's name is entered its id will be fetched.")]
        public void Get_Director_Ids_By_One_Name()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            string directorName = "firstName";  

            List<int> mockDirectorIds = mockBusinessDirector.FindDirectorId(directorName);

            CatalogDbContext cDbContext = mockBusinessDirector.GetCatalogDbContext();
            List<Director> allDirectors = cDbContext.Directors.ToList();

            List<int> directorIds = new List<int>();
            foreach (Director director in allDirectors)
            {
                if (directorName == director.FirstName || directorName == director.LastName)
                {
                    directorIds.Add(director.Id);
                }

            }

            Assert.AreEqual(mockDirectorIds, directorIds, "There are missing directors.");
        }

        [Test, Description("Ensures that when a missing director's name is entered an invalid id will be returned.")]
        public void Get_Invalid_Publisher_Id_By_Missing_Name()
        {
            BusinessDirectors mockBusinessDirector = new BusinessDirectors(mockDbContext.Object);

            string directorName = "yeet420";

            Assert.IsEmpty(mockBusinessDirector.FindDirectorId(directorName), "The director does exist.");
        }
    }
}
