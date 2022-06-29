using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    // ReSharper disable once InconsistentNaming
    public class AppEFContext : IdentityDbContext<ApplicationUser>
    {
        public AppEFContext(DbContextOptions options) : base(options)  
        {
            
        }
        //public Dbset<ApplicationUser> Users { get; set; }
    }
}
