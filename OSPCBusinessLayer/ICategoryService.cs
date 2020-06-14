using OSPCDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSPCBusinessLayer
{
    public interface ICategoryService
    {
        Task<int> AddCategory(Category model);

        Task<int> UpdateCategory(Category model);

        Task<int> DeleteCategory(Category model);

        Task<Category> getViewCategory(Category model);

        Task<List<Category>> GetViewCategories();

    }
}
