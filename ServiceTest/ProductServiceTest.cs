using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSPCWebApi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryServiceTest
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void TestViewProducts()
        {
            // Arrange
            ProductService service = new ProductService();

            // Act
            var products = service.GetViewProducts().Result;

            // Assert
            // Assert.AreNotEqual(expected,actual);
            Assert.IsTrue(products.Count == 8);

        }

        [TestMethod]
        public void TestViewProduct()
        {
            // Arrange
            ProductService service = new ProductService();
            int id = 1;
            // Act
            var product = service.getViewProduct(id).Result;
            
            // Assert
            // Assert.AreNotEqual(expected,actual);
            Assert.IsTrue(product != null);

        }
    }
}
