using ASP.NET_MVC_KENDO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ASP.NET_MVC_KENDO.ViewModels
{
    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}