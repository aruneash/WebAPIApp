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

        public ProductService()
        {
        }

        public async Task<Product> getViewProduct(int id)
        {
            if (db != null)
            {
                var data =  await db.Products.FindAsync(id);
                return GetImagesByProduct(data);
            }

            return null;
        }

        public async Task<List<Product>> GetViewProducts()
        {
            if (db != null)
            {
                var data = await db.Products.ToListAsync();
                return GetImagesByProduct(data);
            }

            return null;
        }

        public List<Product> GetImagesByProduct(List<Product> products)
        {
            if (db != null)
            {
                foreach (var product in products)
                {
                  var imageData = db.Images.SingleOrDefault(x=>x.Id == product.ImageId);
                  product.Image = imageData;
                }
                return products;
            }

            return null;
        }

        public Product GetImagesByProduct(Product model)
        {
            if (db != null)
            {
                    var imageData = db.Images.SingleOrDefault(x => x.Id == model.ImageId);
                    model.Image = imageData;
                
                return model;
            }

            return null;
        }

    }
}
