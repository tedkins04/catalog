using Data.Model;
using System.Data.Entity;
using System.Data.Common;

namespace Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(string strConnection)
            : base(strConnection)
        {
        
        }

        public CatalogDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {
        
        }
        
        
        public CatalogDbContext() 
            : base("name = CatalogDbContext") 
        {
        
        }
         

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
    }
}
