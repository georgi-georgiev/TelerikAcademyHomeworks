using Simple_MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_MVC_Project.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var users = context.Users.ToList().OrderBy(u => u.UserName);
            return View(users);
        }

        public ActionResult ViewUser(string username)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.UserName == username);
            return View(user);
        }
	}
}