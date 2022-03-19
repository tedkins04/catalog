using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Businesses
{
    public class BusinessPublishers
    {
        private CatalogDbContext database;

        public BusinessPublishers()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessPublishers(CatalogDbContext cDbContext)
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
        /// Adds a new publisher to the database.
        /// </summary>
        /// <param name="publisher">The publisher</param>
        public void AddPublisher(Publisher publisher)
        {
            if (publisher != null)
            {
                database.Publishers.Add(publisher);
                database.SaveChanges();
                return;
            }

            throw new ArgumentNullException("Publisher mustn't be empty/null.");            
        }

        /// <summary>
        /// Gets the publisher from the database by their id.
        /// </summary>
        /// <param name="id">The publisher's id</param>
        public Publisher GetPublisher(int id)
        {
            foreach (Publisher publisher in database.Publishers)
            {
                if (id == publisher.Id)
                {
                    return publisher;
                }
            }

            throw new IndexOutOfRangeException("Publisher with this id does not exist!");
        }

        /// <summary>
        /// Deletes the publisher from the database by their id.
        /// </summary>
        /// <param name="id">The publisher's id</param>
        public void DeletePublisher(int id)
        {
            foreach (Publisher publisher in database.Publishers)
            {
                if (id == publisher.Id)
                {
                    database.Publishers.Remove(publisher);
                    database.SaveChanges();
                    return;
                }
            }

            throw new IndexOutOfRangeException("Publisher with this id does not exist!");
        }

        /// <summary>
        /// Gets a list of all publishers from the database.
        /// </summary>
        public List<Publisher> GetAllPublishers()
        {
            return database.Publishers.ToList();
        }

        /// <summary>
        /// Finds the publisher's id based on his name.
        /// </summary>
        /// <param name="publisherName">The publisher's name</param>
        public int FindPublisherId(string publisherName)
        {
            foreach (Publisher publisher in database.Publishers)
            {
                if (publisher.Name.ToLower() == publisherName.ToLower())
                {
                    return publisher.Id;
                }
            }

            return -1;
        }
    }
}
