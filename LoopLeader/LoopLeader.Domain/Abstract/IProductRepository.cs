using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoopLeader.Domain.Entities;

namespace LoopLeader.Domain.Abstract
{
    public interface IProduct
    {
        void AddProduct(Product product);
        IQueryable<Product> Products { get; }

        Product GetProductByProductID(int ProductID);
        Product GetProductByProductName(string ProductName);
        void SaveProduct(Product product);
        Product DeleteProduct(int ProductID);


    }


}
