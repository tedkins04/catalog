using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessCategories
    {
        private CatalogDbContext database;

        public BusinessCategories()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessCategories(CatalogDbContext cDbContext)
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
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="category">The category</param>
        public void AddCategory(Category category)
        {
            if (category != null)
            {
                database.Categories.Add(category);
                database.SaveChanges();
                return;
            }

            throw new ArgumentNullException("Category mustn't be empty/null.");
        }

        /// <summary>
        /// Gets the category from the database by its id.
        /// </summary>
        /// <param name="id">The category's id</param>
        public Category GetCategory(int id)
        {
            foreach (Category category in database.Categories)
            {
                if (id == category.Id)
                {
                    return category;
                }
            }

            throw new IndexOutOfRangeException("Category with this id does not exist!");
        }

        /// <summary>
        /// Deletes a category from the database by its id.
        /// </summary>
        /// <param name="id">The category's id</param>
        public void DeleteCategory(int id)
        {
            foreach (Category category in database.Categories)
            {
                if (id == category.Id)
                {
                    database.Categories.Remove(category);
                    database.SaveChanges();
                    return;
                }
            }

            throw new IndexOutOfRangeException("Category with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all categories from the database.
        /// </summary>
        public List<Category> GetAllCategories()
        {
            return database.Categories.ToList();
        }
    }
}
