using ASP.NET_MVC_KENDO.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using ASP.NET_MVC_KENDO.ViewModels;

namespace ASP.NET_MVC_KENDO.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext context;
        public CategoriesController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult ToolbarTemplate_Categories()
        {

            var categories = context.Categories
                        .Select(c => new CategoryViewModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                        .OrderBy(e => e.Name);

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {
            var categories = context.Categories.Select(CategoryViewModel.FromCategory);
            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategories([DataSourceRequest]DataSourceRequest request, CategoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var category = context.Categories.FirstOrDefault(b => b.Id == model.Id);
                category.Name = model.Name;
                context.SaveChanges();
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategories([DataSourceRequest]DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null)
            {
                var categoryModel = context.Categories.FirstOrDefault(c => c.Id == category.Id);
                context.Categories.Remove(categoryModel);
                context.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CrateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    Name = category.Name,
                };
                context.Categories.Add(newCategory);
                context.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
	}
}