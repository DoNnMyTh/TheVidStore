using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheVidStore.Models;
using AutoMapper;
using TheVidStore.Dtos;

namespace TheVidStore.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET: /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Where(m => m.NumberAvailable >0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }
            var moviesDtos = moviesQuery
            .ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDtos);
        }

        //GET: /api/movies/1
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //POST: /api/movies
        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            var movie = Mapper.Map<MovieDto, Customer>(movieDto);
            _context.Customers.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT: /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpPut]
        public void UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
        }
        //Delete: /api/movies/1
        [Authorize(Roles = RoleName.CanManageMovie)]
        [HttpDelete]
        public void Deletemovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }
    }
}
