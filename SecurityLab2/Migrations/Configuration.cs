using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SecurityLab2.Models;

namespace SecurityLab2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SecurityLab2.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppContext context)
        {
            //Seed database with an admin user and role.

            if (!context.Roles.Any(r => r.Name == "admins"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "admins" };
                roleManager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var userStore = new UserStore<AppUser>(context);
                var userManager = new UserManager<AppUser>(userStore);
                var user = new AppUser
                {
                    UserName = "admin",
                    Email = "fredrik@kodmentor.se",
                    ShoeSize = 42,
                    FavoriteColor = "Yellow"
                };
                userManager.Create(user, "P@ssw0rd");
                userManager.AddToRole(user.Id, "admins");
            }
           
        }
    }
}
