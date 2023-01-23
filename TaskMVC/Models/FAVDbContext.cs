using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace TaskMVC.Models
{
    public class FAVDbContext : DbContext
    {
        public FAVDbContext() : base("Myconnection")
        {

        }
        public DbSet<Product> products{get; set;}

        public DbSet<Category> Categories { get; set; }

        public DbSet<PackSize> PackSizes { get; set; }
    }
}