using System.Web.Security;
using Mvc_project.Models;
using WebMatrix.WebData;

namespace Mvc_project.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mvc_project.Models.MVCProjectDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Mvc_project.Models.MVCProjectDB context)
        {
           /* for (int i = 0; i < 100; i++)
            {
                context.Links.AddOrUpdate(new Link{Title = i.ToString(),Description = "cos",Link = "new link",ShortDescription = "krotko"});
            }*/
        }
    }
}
