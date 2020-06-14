using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OSPCDataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Text;
 


namespace OSPCDataAccessLayer
{
    public class OnlineShoppingContextFactory : IDesignTimeDbContextFactory<OnlineShoppingContext>
    {
        public OnlineShoppingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnlineShoppingContext>();
            //var connection = @"Server=RUNDDU\SQLEXPRESS;Database=OnlineShoppingCard;Trusted_Connection=True;";
            AppConfiguration config = new AppConfiguration();
            optionsBuilder.UseSqlServer(config.ConnectionString);

          

            return new OnlineShoppingContext(optionsBuilder.Options);
        }
    }
}
