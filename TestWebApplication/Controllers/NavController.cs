using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class NavController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = db.Products
                .Select(product => product.Category.Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}