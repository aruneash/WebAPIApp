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

    public class CategoryService : ICategoryService
    {
        ProductService ps = new ProductService();
        OnlineShoppingContext db = new OnlineShoppingContext();
        public CategoryService(OnlineShoppingContext _db, ProductService _ps)
        {
            db = _db;
            ps = _ps;
        }

        public CategoryService()
        {
        }
       
        public async Task<List<Category>> GetViewCategories()
        {
            if (db != null)
            {
                var data = await db.Categories.ToListAsync();
                return GetProducts(data);
            }
           
            return null;
        }

        public async Task<Category> getViewCategory(int id)
        {
            if (db != null)
            {
                var data = await db.Categories.FindAsync(id);
                return GetProducts(data);
            }

            return null;
        }

        public List<Category> GetProducts(List<Category> categories)
        {
            var productList = ps.GetViewProducts().Result;
             

            if (categories != null)
            {
                foreach (var category in categories)
                {
                  category.Products  =   productList.FindAll(x => x.CategoryId == category.Id);
                }
            }


            return categories;
        }

        public Category  GetProducts(Category  category)
        {
            var productList = ps.GetViewProducts().Result;


            if (category != null)
            {
                 category.Products = productList.FindAll(x => x.CategoryId == category.Id);
            }


            return category;
        }

        //public async Task<int> AddCategory(Category model)
        //{
        //    if (db != null)
        //    {
        //        await db.Categories.AddAsync(model);
        //        db.SaveChanges();

        //        return 1;
        //    }
        //    return 0;
        //}

        //public async Task<int> DeleteCategory(int id)
        //{
        //    int result = 0;
        //    if (db != null)
        //    {
        //        var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);

        //        if (category != null)
        //        {

        //            db.Categories.Remove(category);
        //            result =   db.SaveChanges();
        //        }
        //        return result;
        //    }
        //    return result;
        //}

        //public async Task<int> UpdateCategory(Category model)
        //{
        //    if (db != null)
        //    {

        //      //  db.Categories.Update(model);
        //      db.Entry(model).State = EntityState.Modified;
        //      await  db.SaveChangesAsync();

        //     return 1;
        //    }
        //    return 0;
        //}



        //public  bool CategoryExists(int id)
        //{
        //    if (db != null)
        //    {
        //      return   db.Categories.Any(e => e.Id == id);
        //    }

        //    return false;
        //}
    }
}
