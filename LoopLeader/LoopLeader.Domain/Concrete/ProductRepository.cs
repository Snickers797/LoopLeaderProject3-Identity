using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;

namespace LoopLeader.Domain.Concrete
{
    public class ProductRepository : IProduct
    {
        private LLDbContext context = new LLDbContext();

        /// <summary>
        /// List context
        /// </summary>
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
        ///////
        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product">AddProduct</param>
        public void AddProduct(Product product)
        {
            var db = new LLDbContext();
            db.Products.Add(product);
            db.SaveChanges();
        }

        /// <summary>
        /// List of Products
        /// </summary>
        public IQueryable<Product> GetProducts
        {
            get
            {
                var db = new LLDbContext();
                return db.Products;
            }
        }

        /// <summary>
        /// Get Product By ID
        /// </summary>
        /// <param name="productID">GetProductByID</param>
        /// <returns>ProductByID</returns>
        public Product GetProductByProductID(int productID)
        {
            var db = new LLDbContext();
            return (db.Products.First(p => p.ProductID == productID));
        }


        public Product GetProductByProductName(string productName)
        {
            var db = new LLDbContext();
            return (db.Products.First(p => p.ProductName == productName));
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <param name="product">Save Product</param>
        public void SaveProduct(Product product)
        {
            var db = new LLDbContext();
            if (product.ProductID == 0)
            {
                db.Products.Add(product);
            }
            else
            {
                Product dbEntry = db.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.ProductName = product.ProductName;
                    dbEntry.Price = product.Price;
                    //dbEntry.Shipping = product.Shipping;
                    dbEntry.Category = product.Category;
                    dbEntry.Description = product.Description;
                    dbEntry.InStock = product.InStock;//May be disabled if not used?! but must be done in all refd
                }
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productID">DeleteProduct</param>
        /// <returns></returns>
        public Product DeleteProduct(int productID)
        {
            var db = new LLDbContext();
            Product dbEntry = db.Products.Find(productID);
            if (dbEntry != null)
            {
                db.Products.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
