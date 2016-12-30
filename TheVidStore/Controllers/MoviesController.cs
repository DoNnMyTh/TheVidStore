using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheVidStore.Models;
using TheVidStore.ViewModels;

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
            var movies = _context.Movies.ToList();
            return View(movies);
        }







        // GET: Movies/Random

        public ActionResult Random()
        {
            //var movie = new Movie() { Name = "shrek!" };
            var movie = new List<Movie>
            {
                new Movie {Name = "The Green Mile" },
                new Movie {Name = "The Mask" },
                new Movie {Name = "Die Hard" },
                new Movie {Name = "Iron Man" },
                new Movie {Name = "captain America" },
                new Movie {Name = "Thor" },
                new Movie {Name = "Guardians Of Galaxy" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie
            };
            return View(viewModel);
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
    }
}