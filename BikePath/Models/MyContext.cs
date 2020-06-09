using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikePath.Models
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


    }
}
