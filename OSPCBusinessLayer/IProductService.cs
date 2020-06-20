using OSPCDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSPCBusinessLayer
{
    public interface IProductService
    {
        Task<Product> getViewProduct(int id);
        Task<List<Product>> GetViewProducts();
    }
}
