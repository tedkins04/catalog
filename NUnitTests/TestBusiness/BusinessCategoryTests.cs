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
    class BusinessCategoryTests
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

        [Test, Description("Ensures that when added the category stays in the database")]
        public void Add_New_Category_To_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            Category mockCategory = new Category()
            {
                Id = 3,
                Name = "Romance",
            };

            mockBusinessCategory.AddCategory(mockCategory);

            CatalogDbContext cDbContext = mockBusinessCategory.GetCatalogDbContext();

            Assert.Contains(mockCategory, cDbContext.Categories.ToList(), "Category isn't added.");
        }

        [Test, Description("Ensures that when added a category with value null an error is thrown.")]
        public void Add_Null_Category_To_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            Category mockCategory = null;

            Assert.Throws<ArgumentNullException>(() => mockBusinessCategory.AddCategory(mockCategory), "Category with value null was added to the database.");
        }

        [Test, Description("Ensures that a category with the following id and name exists in the database")]
        public void Get_Category_By_Id_From_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            int categoryId = 1;

            Category mockCategory = mockBusinessCategory.GetCategory(categoryId);

            Assert.AreEqual(categoryId, mockCategory.Id, "Wrong category found.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Get_Category_By_Id_That_Is_Not_In_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            int categoryId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessCategory.GetCategory(categoryId));
        }

        [Test, Description("Ensures that a category with the following id will be deleted.")]
        public void Delete_Category_By_Id_From_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            int categoryId = 1;

            int oldCategoryCount = mockBusinessCategory.GetCatalogDbContext().Categories.Count();

            mockBusinessCategory.DeleteCategory(categoryId);

            int currentCategoryCount = mockBusinessCategory.GetCatalogDbContext().Categories.Count();

            Assert.Less(currentCategoryCount, oldCategoryCount, "Category was not deleted.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Delete_Category_By_Id_That_Is_Not_In_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            int categoryId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessCategory.DeleteCategory(categoryId));
        }

        [Test, Description("Ensures that all categories will be gotten/fetched")]
        public void Get_All_Categories_From_Database()
        {
            BusinessCategories mockBusinessCategory = new BusinessCategories(mockDbContext.Object);

            int businessCategoryCount = mockBusinessCategory.GetAllCategories().Count();
            int dbCategoryCount = mockBusinessCategory.GetCatalogDbContext().Categories.Count();

            Assert.AreEqual(businessCategoryCount, dbCategoryCount, "Not all categories were gotten/fetched.");
        }
    }
}
