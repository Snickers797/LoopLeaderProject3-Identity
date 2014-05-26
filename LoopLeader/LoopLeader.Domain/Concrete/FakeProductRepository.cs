using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Concrete
{
    public class FakeProductRepository : IProductRepository
    {

        List<Product> products = new List<Product>();

        
        public IQueryable<Product> Products
        {
            get { return products.AsQueryable(); }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            
        }

        

        public Product GetProductByProductID(int productID)
        {
            return products.First(p => p.ProductID == productID);
        }

        public Product GetProductByProductName(string productName)
        {
            return products.First(p => p.ProductName == productName);
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int ProductID)
        {
            throw new NotImplementedException();
        }
    }
}
