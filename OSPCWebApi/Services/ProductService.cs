using Microsoft.EntityFrameworkCore;
using OSPCBusinessLayer;
using OSPCDataAccessLayer.Context;
using OSPCDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSPCWebApi.Services
{
    public class ProductService : IProductService
    {
        OnlineShoppingContext db = new OnlineShoppingContext();

        public ProductService(OnlineShoppingContext _db)
        {
            db = _db;
        }

        public async Task<Product> getViewProduct(int id)
        {
            if (db != null)
            {
                return await db.Products.FindAsync(id);
            }

            return null;
        }

        public async Task<List<Product>> GetViewProducts()
        {
            if (db != null)
            {
                var data = await db.Products.ToListAsync();
                return data;
            }

            return null;
        }
    }
}
