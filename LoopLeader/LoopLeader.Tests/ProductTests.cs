using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Concrete;
//using LoopLeader.WebUI.Models;

namespace LoopLeader.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void AddProductTest()
        {
            //////////Tests Add Product 
            ////////////// and GetProductByProductID

            //Arrange
            FakeProductRepository repo = new FakeProductRepository();
            Product testProduct1 = new Product();
            testProduct1.ProductID = 1;
            testProduct1.ProductName = "TLL18 Test";
            testProduct1.Price = 39.99M;
            testProduct1.Shipping = 5M;
            testProduct1.InStock = true;

            //Act
            repo.AddProduct(testProduct1);

            //Assert
            Product contentProductRepo = repo.GetProductByProductID(1);
            Assert.AreEqual(contentProductRepo.ProductID, testProduct1.ProductID);
            Assert.AreEqual(contentProductRepo.ProductName, testProduct1.ProductName);

            //////////////////////
            //////////////////////
            //////////Tests Add Product 
            ////////////// and GetProductByProductName
            FakeProductRepository repo2 = new FakeProductRepository();
            Product testProduct2 = new Product();
            testProduct2.ProductID = 2;
            testProduct2.ProductName = "TLL24 Test";
            testProduct2.Price = 49.99M;
            testProduct2.Shipping = 5M;
            testProduct2.InStock = true;

            //Act
            repo.AddProduct(testProduct2);

            //Assert
            Product contentProductRepo2 = repo.GetProductByProductName("TLL24 Test");
            Assert.AreEqual(contentProductRepo2.ProductID, testProduct2.ProductID);
            Assert.AreEqual(contentProductRepo2.ProductName, testProduct2.ProductName);
        }

        



    }
}
