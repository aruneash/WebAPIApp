using OSPCDataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSPCDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.ComponentModel;

namespace OSPCWebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OnlineShoppingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Products or Categories.
            if (context.Products.Any() || context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            string date = DateTime.Now.ToString("MM/dd/yyyy");

            //Add Categories
            var categories = new Category[]
                {
                    new Category{Name = "Men's Shoes", CreatedDate = DateTime.Parse(date),IsActive = true},
                    new Category{Name = "Women's Shoes", CreatedDate = DateTime.Parse(date),IsActive = true},
                    new Category{Name = "Accessories", CreatedDate = DateTime.Parse(date),IsActive = true},
                    new Category{Name = "Clothing", CreatedDate = DateTime.Parse(date),IsActive = true}
                };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            //Add Images
            var images = new Image[]
                {
                    new Image{ ImagePath = "../../assets/images/product-1.png"},
                    new Image{ ImagePath = "../../assets/images/product-2.png"},
                    new Image{ ImagePath = "../../assets/images/product-3.png"},
                    new Image{ ImagePath = "../../assets/images/product-4.png"},
                    new Image{ ImagePath = "../../assets/images/product-5.png"},
                    new Image{ ImagePath = "../../assets/images/product-6.png"},
                    new Image{ ImagePath = "../../assets/images/product-7.png"},
                    new Image{ ImagePath = "../../assets/images/product-8.png"},
                };

            context.Images.AddRange(images);
            context.SaveChanges();

            //Add Products
            var desc = "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.";
                desc += " ";
                desc += "everything that was left from its origin would be the word and and the Little Blind Text should turn around and return to its own, safe country. But nothing the copy said could convince her and so it didn’t take long until a few insidious Copy Writers ambushed her, made her drunk with Longe and Parole and dragged her into their agency, where they abused her for their.";

            var products = new Product[]
            {

                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=120,Discount=0, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 1,ImageId=1,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=80,Discount=50, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 2,ImageId=2,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=120,Discount=0, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 3,ImageId=3,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=120,Discount=0, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 4,ImageId=4,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=120,Discount=0, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 1,ImageId=5,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=80,Discount=50, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 2,ImageId=6,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=120,Discount=0, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 3,ImageId=7,IsActive = true},
                new Product{Name="NIKE FREE RN 2019 ID",Description=desc,Qty =10,SellingPrice=120,Discount=0, UnitPrice = 120, CreatedDate=DateTime.Parse(date),CategoryId = 4,ImageId=8,IsActive = true},
            };

            context.Products.AddRange(products);

            context.SaveChanges();
 
        }
    }
}
