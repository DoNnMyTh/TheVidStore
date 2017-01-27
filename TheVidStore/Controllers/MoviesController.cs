using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVidStore.Models;
using TheVidStore.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace TheVidStore.Controllers
{
    public class MoviesController : Controller
    {








        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }











        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }








        public ActionResult Index()
        {
            return View();
        }












        // GET: Movies/Det

        public ActionResult Det(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);
            {
                if (movies == null)
                    return HttpNotFound();
                else
                    return View(movies);
            };
        }









        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }





        // GET: Movies/Index/{}/{}
        /* public ActionResult Index(int? pageIndex, string shortBy)
         {
             if (!pageIndex.HasValue)
                 pageIndex = 1;
             if (String.IsNullOrWhiteSpace(shortBy))
                 shortBy = "Name";
             return Content(string.Format("pageIndex={0}&shortBy={1}", pageIndex, shortBy));
         }*/









        // GET: Movies/ByReleaseDate/{year}/{month}
        /* public ActionResult ByReleaseDate(int year, int month)
         {
             return Content(year + "/" + month);
         }
       */







        public ActionResult NewMovie()
        {
            var ViewModel = new NewMovieViewModel
            {
                Movie = new Movie()
            };
            return View("NewMovie",ViewModel);
        }





        public ActionResult EditMovie(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (Movie == null)

            {
                return HttpNotFound();
            }
            var ViewModel = new NewMovieViewModel
            {
                Movie = Movie
            };

            return View("NewMovie", ViewModel);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovies(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new NewMovieViewModel
                {
                    Movie = movie
                };
                return View("NewMovie", ViewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.NumberOfMovies = movie.NumberOfMovies;
                MovieInDb.GenreOfMovie = movie.GenreOfMovie;
                MovieInDb.Year = movie.Year;
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }


        }
    }
}