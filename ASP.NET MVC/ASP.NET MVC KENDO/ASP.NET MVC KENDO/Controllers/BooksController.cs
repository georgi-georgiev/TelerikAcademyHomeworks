using ASP.NET_MVC_KENDO.Models;
using ASP.NET_MVC_KENDO.ViewModels;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Kendo.Mvc.Extensions;

namespace ASP.NET_MVC_KENDO.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private ApplicationDbContext context;

        
        public BooksController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewBook(int id)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        public JsonResult GetBooksTitles(string text)
        {
            var books = context.Books.Where(b => b.Title.ToLower().Contains(text.ToLower())).Select(BookViewModel.FromBook);
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadBooks([DataSourceRequest]DataSourceRequest request)
        {
            var categories = context.Books.Include("Categories").Select(BookViewModel.FromBook);
            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBooks([DataSourceRequest]DataSourceRequest request, BookViewModel model)
        {
            if(model != null && ModelState.IsValid)
            {
                var book = context.Books.FirstOrDefault(b => b.Id == model.Id);
                book.Title = model.Title;
                book.ISBN = model.ISBN;
                book.Website = model.Website;
                book.Content = model.Content;
                book.Author = model.Author;
                book.Category = context.Categories.FirstOrDefault(c => c.Name == model.CategoryName);
                context.SaveChanges();
            }
            return Json(new [] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBooks([DataSourceRequest]DataSourceRequest request, BookViewModel book)
        {
            if (book != null)
            {
                var bookModel = context.Books.FirstOrDefault(b => b.Id == book.Id);
                context.Books.Remove(bookModel);
                context.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CreateBooks([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var newBook = new Book()
                {
                    Title=book.Title,
                    Author=book.Author,
                    ISBN=book.ISBN,
                    Content=book.Content,
                    Website=book.Website,
                    Category=context.Categories.FirstOrDefault(c => c.Name == book.CategoryName),
                };
                context.Books.Add(newBook);
                context.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }
	}
}