using System.Data.Entity;

namespace FrontenedWeb.Models
{
    public class MvcProjectDb:DbContext

    {
        public MvcProjectDb()
            : base("name=DefaultConnection")        
        {

            Database.SetInitializer<MvcProjectDb>(new CreateDatabaseIfNotExists<MvcProjectDb>());
        }
        
        public DbSet<Link> Links { get; set; }
        public DbSet<UserBase> UsersBase { get; set; }
    }
}