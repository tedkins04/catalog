using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessAuthors
    {
        private CatalogDbContext database;

        public BusinessAuthors()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessAuthors(CatalogDbContext cDbContext)
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
        /// Adds a new author  to the database.
        /// </summary>
        /// <param name="author">The author</param>
        public void AddAuthor(Author author)
        {
            if (author != null)
            {
                database.Authors.Add(author);
                database.SaveChanges();
                return;
            }

            throw new ArgumentNullException("Author mustn't be empty/null.");
        }

        /// <summary>
        /// Gets the author from the database by his id.
        /// </summary>
        /// <param name="id">The author's id</param>
        public Author GetAuthor(int id)
        {
            foreach (Author author in database.Authors)
            {
                if (author.Id == id)
                {
                    return author;
                }
            }

            throw new IndexOutOfRangeException("Author with this id does not exist!");
        }

        /// <summary>
        /// Deletes the author from the database by his id.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAuthor(int id)
        {
            foreach (Author author in database.Authors)
            {
                if(id == author.Id)
                {
                    database.Authors.Remove(author);
                    database.SaveChanges();
                    return;
                }
            }

            throw new IndexOutOfRangeException("Author with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all the authors from the database.
        /// </summary>
        public List<Author> GetAllAuthors()
        {
            return database.Authors.ToList();
        }

        /// <summary>
        /// Finds the author's id based on his first and last name.
        /// </summary>
        /// <param name="authorFirstName">The author's first name</param>
        /// <param name="authorLastName">The author's last name</param>
        public int FindAuthorId(string authorFirstName, string authorLastName)
        {
            foreach (Author author in database.Authors)
            {
                if (author.FirstName.ToLower().Equals(authorFirstName.ToLower()) && author.LastName.ToLower().Equals(authorLastName.ToLower()))
                {
                    return author.Id;
                }
            }

            throw new InvalidOperationException("Author with this name does not exist!");
        }
    }
}
