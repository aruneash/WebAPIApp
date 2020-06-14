using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSPCDataAccessLayer.Models
{
    public class OSPCDBContext : DbContext
    {
        public OSPCDBContext(DbContextOptions<OSPCDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
