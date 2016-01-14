using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SecurityLab2.Models
{
    public class AppUser: IdentityUser
    {
        public string FavoriteColor { get; set; }
        public int ShoeSize { get; set; }

    }
}