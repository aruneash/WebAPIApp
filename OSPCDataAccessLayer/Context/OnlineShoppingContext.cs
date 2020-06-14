using Microsoft.EntityFrameworkCore;
using OSPCDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSPCDataAccessLayer.Context
{
   public class OnlineShoppingContext : DbContext
    {

        public OnlineShoppingContext(DbContextOptions<OnlineShoppingContext> options)
           : base(options)
        {
        }
        public OnlineShoppingContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().ToTable("Product");
        //    modelBuilder.Entity<Category>().ToTable("Category");
        //}


    }
}
