using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSPCDataAccessLayer.Context;
using OSPCDataAccessLayer.Entities;
using OSPCWebApi.Services;
using System;
using System.Collections.Generic;

namespace CategoryServiceTest
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        public void TestAddCategory()
        {
            // Arrange
            CategoryService service = new CategoryService();

            var modelProduct = new List<Product>();

            var model = new Category
            {
                Name = "Puma",
                CreatedDate = DateTime.Now,
                IsActive = true,
                Product = modelProduct
            };

            // Act
            var actual = service.AddCategory(model);

            // Assert
            Assert.AreEqual(1, actual.Result);

        }
    }
}
