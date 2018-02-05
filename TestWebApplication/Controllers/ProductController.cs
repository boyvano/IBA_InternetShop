using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private ApplicationDbContext db = new ApplicationDbContext();
        public int pageSize = 4;

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = db.Products
            .Where(p => category == null || p.Category.Name == category)
            .OrderBy(product => product.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        db.Products.Count() :
        db.Products.Where(product => product.Category.Name == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
}
}