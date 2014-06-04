using LoopLeader.Models;
using System.Data.Entity.Migrations;

namespace LoopLeader.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationsEnabled = false;
            //ContextKey = "LoopLeader.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.AddUserAndRoles();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new LoopLeader.Models.ApplicationDbContext.IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;

            success = idManager.CreateRole("User");
            if (!success) return success;

            var newUser = new ApplicationUser()
            {
                UserName = "Skip",
                FirstName = "Skip",
                LastName = "McDonald",
                EmailAddress = "contacteyemac@gmail.com",
                StreetAddress = "123 Main St.",
                City = "Eugene",
                State = "Oregon",
                Country = "USA"

            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password123");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            return success;
        }
    }
}
