using Microsoft.EntityFrameworkCore;
using poc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poc.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) { }

        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users {get;set;}

        public DbSet<Policy> Policies {get;set;}
    }
}
