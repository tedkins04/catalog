using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessDirectors
    {
        private CatalogDbContext database;

        public BusinessDirectors()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessDirectors(CatalogDbContext cDbContext)
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
        /// Adds a new director to the database.
        /// </summary>
        /// <param name="director">The director</param>
        public void AddDirector(Director director)
        {
            if (director != null)
            {
                database.Directors.Add(director);
                database.SaveChanges();
                return;
            }

            throw new ArgumentNullException("Director mustn't be empty/null.");
        }

        /// <summary>
        /// Gets the director from the database by his id.
        /// </summary>
        /// <param name="id">The director's id</param>
        public Director GetDirector(int id)
        {
            foreach (Director director in database.Directors)
            {
                if (director.Id == id)
                {
                    return director;
                }
            }

            throw new IndexOutOfRangeException("Director with this id does not exist!");
        }

        /// <summary>
        /// Deletes the director from the database by his id.
        /// </summary>
        /// <param name="id">The director's id</param>
        public void DeleteDirector(int id)
        {
            foreach (Director director in database.Directors)
            {
                if (director.Id == id)
                {
                    database.Directors.Remove(director);
                    database.SaveChanges();
                    return;
                }
            }

            throw new IndexOutOfRangeException("Director with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all directors from the database.
        /// </summary>
        public List<Director> GetAllDirectors()
        {
            return database.Directors.ToList();
        }
        
        /// <summary>
        /// Finds the director's id based on his name.
        /// </summary>
        /// <param name="directorName">The director's name</param>
        public List<int> FindDirectorId(string directorName)
        {
            string[] directorFullName = directorName.Split().ToArray();
            List<int> directorIds = new List<int>();

            if (directorFullName.Length > 1)
            {
                string directorFirstName = directorFullName[0];
                string directorLastName = directorFullName[1];

                foreach (Director director in database.Directors)
                {
                    if (director.FirstName.ToLower().Equals(directorFirstName.ToLower()) && director.LastName.ToLower().Equals(directorLastName.ToLower()))
                    {
                        directorIds.Add(director.Id);
                    }
                }
            }
            else if (directorFullName.Length == 1)
            {
                string directorKnownName = directorFullName[0];


                foreach (Director director in database.Directors)
                {
                    if (director.FirstName.ToLower().Equals(directorKnownName.ToLower()) || director.LastName.ToLower().Equals(directorKnownName.ToLower()))
                    {
                        directorIds.Add(director.Id);
                    }
                }
            }
            else
            {
                return new List<int>();
            }

            return directorIds;
        }
    }
}
