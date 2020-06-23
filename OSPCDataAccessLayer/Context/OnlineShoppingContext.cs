using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OSPCDataAccessLayer.Entities;
using System.IO;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany<Product>(s => s.Products)
                .WithOne(g => g.Category)
                .HasForeignKey(s => s.CategoryId);


            modelBuilder.Entity<Product>()
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.CategoryId);
        }

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
