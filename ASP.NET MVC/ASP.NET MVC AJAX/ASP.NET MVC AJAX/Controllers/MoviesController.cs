using ASP.NET_MVC_AJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_AJAX.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }

        public ActionResult ViewMovie(int id)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult DeleteMovie(int id)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == id);
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return PartialView("_CreateMovieForm");
        }
        public ActionResult EditMovie(int id)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == id);
            return PartialView("_EditMovieForm", movie);
        }

        public ActionResult UpdateMovie(Movie newMovie)
        {
            var movie = context.Movies.FirstOrDefault(m => m.Id == newMovie.Id);
            movie.LeadingFRole = newMovie.LeadingFRole;
            movie.LeadingMRole = newMovie.LeadingMRole;
            movie.Studio = newMovie.Studio;
            movie.StudioAddress = newMovie.StudioAddress;
            movie.Title = newMovie.Title;
            movie.Director = newMovie.Director;
            movie.LeadingMRoleAge = newMovie.LeadingMRoleAge;
            movie.LeadingFRoleAge = newMovie.LeadingFRoleAge;
            context.SaveChanges();

            return RedirectToAction("ViewMovie", new { id = newMovie.Id });
        }

        public ActionResult CreateMovie(Movie newMovie)
        {
            context.Movies.Add(newMovie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}