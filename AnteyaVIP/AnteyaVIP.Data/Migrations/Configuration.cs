namespace AnteyaVIP.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<AnteyaVIPDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AnteyaVIPDbContext context)
        {
          //  context.Database.ExecuteSqlCommand("ALTER TABLE Categories ADD CONSTRAINT uc_Name UNIQUE(Name)");
            //if (context.Roles.Any())
            //{
            //    return;
            //}

            //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "trusted"
            //});
            //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "admin"
            //});
            //context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "non-trusted"
            //});

            //context.SaveChanges();
        }
    }
}
