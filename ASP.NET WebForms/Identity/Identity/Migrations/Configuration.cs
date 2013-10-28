using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                context.Roles.AddOrUpdate(new Role("Administrator"));
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                context.Roles.AddOrUpdate(new Role("Moderator"));
            }
            context.SaveChanges();
        }
    }
}
