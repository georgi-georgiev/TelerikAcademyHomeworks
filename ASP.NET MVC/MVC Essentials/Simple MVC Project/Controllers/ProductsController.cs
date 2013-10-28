using Simple_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_MVC_Project.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var products = context.Products.ToList();
            return View(products);
        }
	}
}