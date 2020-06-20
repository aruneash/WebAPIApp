using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OSPCDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace OSPCDataAccessLayer.Context
{
   public class OnlineShoppingContext : DbContext
    {

        public OnlineShoppingContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString);
        //}

        public OnlineShoppingContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DBConnString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
