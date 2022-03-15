using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Setting up so a user can login. Inherits from Identity Context of type IdentityUser

namespace BookStore.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        //Constructor
        public AppIdentityDBContext(DbContextOptions options) : base(options) // next go to appsettings.json
        {
        }
    }
}
