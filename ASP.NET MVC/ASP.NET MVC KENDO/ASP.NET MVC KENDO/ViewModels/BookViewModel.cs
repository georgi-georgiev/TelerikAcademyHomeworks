using ASP.NET_MVC_KENDO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ASP.NET_MVC_KENDO.ViewModels
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return book => new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Content = book.Content,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    Website = book.Website,
                    CategoryName = book.Category.Name
                };
            }
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }

        public string Content { get; set; }

        public string Website { get; set; }
        public string CategoryName { get; set; }
    }
}