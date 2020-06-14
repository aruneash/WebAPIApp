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
        OnlineShoppingContext db = new OnlineShoppingContext();
        public CategoryService(OnlineShoppingContext _db)
        {
            db = _db;
        }

        public CategoryService()
        {
        }

        public async Task<int> AddCategory(Category model)
        {
            if (db != null)
            {
                await db.Categories.AddAsync(model);
                await db.SaveChangesAsync();

                return 1;
            }
            return 0;
        }

        public async Task<int> DeleteCategory(Category model)
        {
            int result = 0;
            if (db != null)
            {
                var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (category != null)
                {
                     
                    db.Categories.Remove(category);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<int> UpdateCategory(Category model)
        {
            if (db != null)
            {
                 
                db.Categories.Update(model);

                //Commit the transaction
               return await db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Category>> GetViewCategories()
        {
            if (db != null)
            {
                return await db.Categories.ToListAsync();
            }

            return null;
        }

        public async Task<Category> getViewCategory(Category model)
        {
            if (db != null)
            {
                return await db.Categories.FindAsync(model.Id);
            }

            return null;
        }
     
    }
}
