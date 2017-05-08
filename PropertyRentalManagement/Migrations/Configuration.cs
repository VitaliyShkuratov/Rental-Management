namespace PropertyRentalManagement.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PropertyRentalManagement.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PropertyRentalManagement.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "tenant"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "tenant" };

                manager.Create(role);
            }

            if (!(context.Users.Any(u => u.UserName == "admin@mail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser
                {
                    Email = "admin@mail.com",
                    UserName = "admin@mail.com",
                    PhoneNumber = "000-000-0000"
                };
                userManager.Create(userToInsert, "Admin-123");
                userManager.AddToRole(userToInsert.Id, "admin");
            }




            if (!(context.Users.Any(u => u.UserName == "manager@mail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser
                {
                    Email = "manager@mail.com",
                    UserName = "manager@mail.com",
                    PhoneNumber = "111-111-1111"
                };
                userManager.Create(userToInsert, "Manager-123");
                userManager.AddToRole(userToInsert.Id, "manager");
            }
        }
    }
 }