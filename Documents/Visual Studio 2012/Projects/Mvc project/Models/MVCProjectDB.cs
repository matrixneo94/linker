using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_project.Models
{
    public class MVCProjectDB:DbContext

    {
        public MVCProjectDB()
            : base("name=DefaultConnection")        
        {

            Database.SetInitializer<MVCProjectDB>(new DropCreateDatabaseIfModelChanges<MVCProjectDB>());
        }
        
        public DbSet<Link> Links { get; set; }
        public DbSet<UserBase> UsersBase { get; set; }
    }
}