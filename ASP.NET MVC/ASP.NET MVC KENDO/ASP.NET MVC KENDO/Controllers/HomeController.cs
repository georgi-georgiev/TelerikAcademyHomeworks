using ASP.NET_MVC_KENDO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_KENDO.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchBooks(string query)
        {
            ViewBag.Results = query;
            var books = context.Books.Where(b => b.Title.Contains(query) || b.Author.Contains(query)).ToList();
            return View(books);
        }
    }
}