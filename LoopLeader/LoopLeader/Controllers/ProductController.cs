using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;
using LoopLeader.Domain.Concrete;
//using LoopLeader.WebUI.Models;
using LoopLeader.Models;

namespace LoopLeader.Controllers
{
    public class ProductController : Controller
    {
        private IProduct repository;
        public int PageSize = 2;       // 2 products per page
        public ProductController()
        {
            // repository = new FakeProductRepository();
            repository = new ProductRepository();
        }

        public ProductController(IProduct productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            /*
            return View(repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                );
             */
            ProductsListViewModel model = new ProductsListViewModel
            {
                // Get a list of products, put it in the model
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                // Put the paging info in the model too
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }



        public ActionResult CheckoutConfirm(ProductsListViewModel viewModel)
        {
            return View(viewModel);
        }


    }
}
