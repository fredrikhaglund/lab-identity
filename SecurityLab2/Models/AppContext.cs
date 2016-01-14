using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityLab2.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : IdentityDbContext<AppUser>
    {

        public AppContext(): base("name=AppContext")
        {

            // Add DbSet for other enteties ...
        }

    }

}