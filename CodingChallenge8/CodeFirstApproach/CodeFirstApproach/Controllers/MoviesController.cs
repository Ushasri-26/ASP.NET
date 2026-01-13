using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Models;
using CodeFirstApproach.Repository;

namespace CodeFirstApproach.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();
        // GET: Movies
        public ActionResult Index()
        {
            var movies = repo.GetAllMovies();
            return View(movies);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movie = repo.GetMovieById(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.UpdateMovie(movie);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            repo.DeleteMovie(id);
            return RedirectToAction("Index");
        }
        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetMoviesByYear(year);
            return View(movies);
        }
        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetMoviesByDirector(directorName);
            return View(movies);
        }
    }
}