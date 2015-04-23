using System.Data.Entity;
using FrontenedWeb.Models;
using WebMatrix.WebData;

namespace FrontenedWeb.DBContext
{
    public class LinkerDb:DbContext

    {
        public LinkerDb()
            : base("name=DefaultConnection")        
        {

            Database.SetInitializer<LinkerDb>(new CreateDatabaseIfNotExists<LinkerDb>());
           
        }
        
        public DbSet<Link> Links { get; set; }
        public DbSet<UserBase> UsersBase { get; set; }
    }
}