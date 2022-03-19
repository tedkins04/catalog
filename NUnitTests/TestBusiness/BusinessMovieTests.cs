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
    class BusinessMovieTests
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

        [Test, Description("Ensures that when added the movie stays in the database")]
        public void Add_New_Movie_To_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            Movie mockMovie = new Movie()
            {
                Id = 3,
                Title = "title",
                DirectorId = 1,
                ActorIds = "1",
                PublicationYear = 1234,
                CategoryIds = "1"
            };

            mockBusinessMovie.AddMovie(mockMovie);

            CatalogDbContext cDbContext = mockBusinessMovie.GetCatalogDbContext();

            Assert.Contains(mockMovie, cDbContext.Movies.ToList(), "Movie isn't added.");
        }

        [Test, Description("Ensures that when added a movie with value null an error is thrown.")]
        public void Add_Null_Movie_To_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            Movie mockMovie = null;

            Assert.Throws<ArgumentNullException>(() => mockBusinessMovie.AddMovie(mockMovie), "Movie with value null was added to the database.");
        }

        [Test, Description("Ensures that a movie with the following id and name exists in the database")]
        public void Get_Movie_By_Id_From_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int movieId = 1;

            Movie mockMovie = mockBusinessMovie.GetMovie(movieId);

            Assert.AreEqual(movieId, mockMovie.Id, "Wrong movie found.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Get_Movie_By_Id_That_Is_Not_In_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int movieId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessMovie.GetMovie(movieId));
        }

        [Test, Description("Ensures that a movie with the following id will be deleted.")]
        public void Delete_Movie_By_Id_From_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int movieId = 1;

            int oldMovieCount = mockBusinessMovie.GetCatalogDbContext().Movies.Count();

            mockBusinessMovie.DeleteMovie(movieId);

            int currentMovieCount = mockBusinessMovie.GetCatalogDbContext().Movies.Count();

            Assert.Less(currentMovieCount, oldMovieCount, "Movie was not deleted.");
        }

        [Test, Description("Ensures that an exception is thrown when an id, that doesn't exist in the database, is entered.")]
        public void Delete_Movie_By_Id_That_Is_Not_In_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int movieId = 100;

            Assert.Throws<IndexOutOfRangeException>(() => mockBusinessMovie.DeleteMovie(movieId));
        }

        [Test, Description("Ensures that all movies will be gotten/fetched")]
        public void Get_All_Movies_From_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int businessMovieCount = mockBusinessMovie.GetAllMovies().Count();
            int dbMovieCount = mockBusinessMovie.GetCatalogDbContext().Movies.Count();

            Assert.AreEqual(businessMovieCount, dbMovieCount, "Not all movies were gotten/fetched.");
        }

        [Test, Description("Ensures that all movies with the chosen category will be fetched.")]
        public void Get_All_Movies_By_Category_Id_From_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int categoryId = 1;
            List<Movie> mockMoviesWithCategory = mockBusinessMovie.GetMoviesByCategory(categoryId).ToList();

            CatalogDbContext cDbContext = mockBusinessMovie.GetCatalogDbContext();
            List<Movie> movieksWithCategory = new List<Movie>();

            foreach (Movie movie in cDbContext.Movies)
            {
                if (movie.CategoryIds.Split().Select(int.Parse).ToList().Contains(categoryId))
                {
                    movieksWithCategory.Add(movie);
                }
            }

            Assert.AreEqual(movieksWithCategory, mockMoviesWithCategory, "Not all movies with the same category were fetched.");
        }

        [Test, Description("Ensures that when an invalid category is selected an empty list will be returned.")]
        public void Get_Movies_By_Invalid_Category_Id()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int categoryId = 10;
            List<Movie> mockMoviesWithCategory = mockBusinessMovie.GetMoviesByCategory(categoryId).ToList();

            Assert.IsEmpty(mockMoviesWithCategory);
        }

        [Test, Description("Ensures that all movies with the chosen key name/title will be fetched.")]
        public void Get_All_Movies_By_Title_From_Database()
        {
            BusinessMovies mockBusinessMovie  = new BusinessMovies(mockDbContext.Object);

            string movieTitle = "title";
            List<Movie> mockMoviesWithTitle = mockBusinessMovie.GetMoviesByTitle(movieTitle).ToList();

            CatalogDbContext cDbContext = mockBusinessMovie.GetCatalogDbContext();
            List<Movie> moviesWithTitle = new List<Movie>();

            foreach (Movie movie in cDbContext.Movies)
            {
                if (movie.Title.ToLower().Contains(movieTitle))
                {
                    moviesWithTitle.Add(movie);
                }
            }

            Assert.AreEqual(moviesWithTitle, mockMoviesWithTitle, "Not all movies with the same key name/title were fetched.");
        }

        [Test, Description("Ensures that when a missing title is entered an empty list will be returned.")]
        public void Get_Movies_By_Missing_Title()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            string movieTitle = "yeet420";
            List<Movie> mockMoviesWithTitle = mockBusinessMovie.GetMoviesByTitle(movieTitle).ToList();

            Assert.IsEmpty(mockMoviesWithTitle, "There do exist movies with that title.");
        }

        [Test, Description("Ensures that all movies with the chosen publisher will be fetched.")]
        public void Get_All_Movies_By_Director_From_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            string movieDirector = "name1";
            List<Movie> mockMoviesWithDirector = mockBusinessMovie.GetMoviesByDirector(movieDirector).ToList();

            CatalogDbContext cDbContext = mockBusinessMovie.GetCatalogDbContext();
            BusinessDirectors testBusinessDirector = new BusinessDirectors(mockDbContext.Object);
            List<Movie> moviesWithDirector = new List<Movie>();
            List<int> directorIds = testBusinessDirector.FindDirectorId(movieDirector);

            foreach (Movie movie in cDbContext.Movies)
            {
                if (directorIds.Contains(movie.DirectorId))
                {
                    moviesWithDirector.Add(movie);
                }
            }

            Assert.AreEqual(moviesWithDirector, mockMoviesWithDirector, "Not all movies with the same director were fetched.");
        }

        [Test, Description("Ensures that when a missing director is entered an empty list will be returned.")]
        public void Get_Books_By_Missing_Director()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            string movieDirector = "yeet420";
            List<Movie> mockMoviesWithDirector = mockBusinessMovie.GetMoviesByDirector(movieDirector).ToList();

            Assert.IsEmpty(mockMoviesWithDirector, "There does exist such director.");
        }

        [Test, Description("Ensures that all movies with the chosen actor will be fetched.")]
        public void Get_All_Movies_By_Actor_Id_From_Database()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int actorId = 1;
            List<Movie> mockMoviesWithActor = mockBusinessMovie.GetMoviesByActorId(actorId).ToList();

            CatalogDbContext cDbContext = mockBusinessMovie.GetCatalogDbContext();
            List<Movie> moviesWithActor = new List<Movie>();

            foreach (Movie movie in cDbContext.Movies)
            {
                if (movie.ActorIds.Split().Select(int.Parse).Contains(actorId))
                {
                    moviesWithActor.Add(movie);
                }
            }

            Assert.AreEqual(moviesWithActor, mockMoviesWithActor, "Not all movies with the same actor were fetched.");
        }

        [Test, Description("Ensures that when an invalid actor is selected an empty list will be returned.")]
        public void Get_Books_By_Invalid_Actor_Id()
        {
            BusinessMovies mockBusinessMovie = new BusinessMovies(mockDbContext.Object);

            int actorId = 10;
            List<Movie> mockBooksWithActor = mockBusinessMovie.GetMoviesByActorId(actorId).ToList();

            Assert.IsEmpty(mockBooksWithActor, "There does exist an actor with that id.");
        }
    }
}
