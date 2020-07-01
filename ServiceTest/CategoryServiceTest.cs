using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSPCDataAccessLayer.Entities;
using OSPCWebApi.Services;
using System.Collections.Generic;
using System.Linq;

namespace CategoryServiceTest
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        public void TestViewCategories()
        {
            // Arrange
            CategoryService service = new CategoryService();

            // Act
            var categories = service.GetViewCategories().Result;

            // Assert
            // Assert.AreNotEqual(expected,actual);
            Assert.IsTrue(categories.Count == 4);
            Assert.IsTrue(categories.All(x=>x.Products.Count != 0 ));

        }
        [TestMethod]
        public void TestViewCategory()
        {
            // Arrange
            CategoryService service = new CategoryService();
            int id = 1;
            // Act
            var category = service.getViewCategory(id).Result;

            // Assert
            // Assert.AreNotEqual(expected,actual);
            Assert.IsTrue(category != null);
            Assert.IsTrue(category.Products.Count != 0);

        }

        //[TestMethod]
        //public void TestAddCategory()
        //{
        //    // Arrange
        //    CategoryService service = new CategoryService();

        //    var modelProduct = new List<Product>();

        //    var model = new Category
        //    {
        //        Name = "Puma",
        //        CreatedDate = DateTime.Now,
        //        IsActive = true,
        //        Products = modelProduct
        //    };

        //    // Act
        //    var actual = service.AddCategory(model);

        //    // Assert
        //    Assert.AreEqual(1, actual.Result);

        //}

    }
}
