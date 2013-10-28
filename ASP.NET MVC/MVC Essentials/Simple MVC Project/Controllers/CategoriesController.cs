using Simple_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_MVC_Project.Controllers
{
    public class CategoriesController : Controller
    {
        //
        // GET: /Categories/
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var categories = context.Categories.ToList();
            return View(categories);
        }
	}
}