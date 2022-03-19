using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Businesses
{
    public class BusinessActors
    {
        private CatalogDbContext database;

        public BusinessActors()
        {
            database = new CatalogDbContext();
        }

        /// <summary>
        /// Constructor that reupdates the database context.
        /// </summary>
        public BusinessActors(CatalogDbContext cDbContext)
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
        /// Adds a new actor to the database.
        /// </summary>
        /// <param name="actor"></param>
        public void AddActor(Actor actor)
        {
            if (actor != null)
            {
                database.Actors.Add(actor);
                database.SaveChanges();
                return;
            }

            throw new ArgumentNullException("Actor mustn't be empty/null.");
        }

        /// <summary>
        /// Gets the actor from the database by his id.
        /// </summary>
        /// <param name="id">The actor's id</param>
        public Actor GetActor(int id)
        {
            foreach (Actor actor in database.Actors)
            {
                if (id == actor.Id)
                {
                    return actor;
                }
            }

            throw new IndexOutOfRangeException("Actor with this id does not exist!");
        }

        /// <summary>
        /// Deletes the actor from the database by id.
        /// </summary>
        /// <param name="id">The actor's id</param>
        public void DeleteActor(int id)
        {
            foreach (Actor actor in database.Actors)
            {
                if (id == actor.Id)
                {
                    database.Actors.Remove(actor);
                    database.SaveChanges();
                    return;
                }
            }

            throw new IndexOutOfRangeException("Actor with this id does not exist!");     
        }

        /// <summary>
        /// Gets a list of all the actors from the database.
        /// </summary>
        public List<Actor> GetAllActors()
        {
            return database.Actors.ToList();
        }

        /// <summary>
        /// Finds the actor's id based on his first and last name.
        /// </summary>
        /// <param name="actorFirstName">The actor's first name</param>
        /// <param name="actorLastName">The actor's last name</param>
        public int FindActorId(string actorFirstName, string actorLastName)
        {
            foreach (Actor actor in database.Actors)
            {
                if (actor.FirstName.ToLower().Equals(actorFirstName.ToLower()) && actor.LastName.ToLower().Equals(actorLastName.ToLower()))
                {
                    return actor.Id;
                }
            }

            throw new InvalidOperationException("Actor with this names does not exist!");
        }
    }
}
