using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoopLeader.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public List<LoopLeader.Domain.Entities.Product> ProductList { get; set; }
    }
}