using OSPCDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSPCBusinessLayer
{
    public interface ICategoryService
    {
        //Task<int> AddCategory(Category model);

        //Task<int> UpdateCategory(Category model);

        //Task<int> DeleteCategory(int id);

        Task<Category> getViewCategory(int id);

        Task<List<Category>> GetViewCategories();

        //bool CategoryExists(int id);
        
    }
}
