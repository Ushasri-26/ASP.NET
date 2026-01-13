using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirstApproach.Models;
using System.Data.Entity;

namespace CodeFirstApproach.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviesDbContext db = new MoviesDbContext();
        //create a movie
        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }
        //update a movie
        public void UpdateMovie(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }
        //delete a movie
        public void DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }
        public Movie GetMovieById(int id)
        {
            return db.Movies.Find(id);
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            return db.Movies.ToList();
        }
        //get by year
        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            return db.Movies
                     .Where(m => m.DateOfRelease.Year == year)
                     .ToList();
        }
        //get by director
        public IEnumerable<Movie> GetMoviesByDirector(string directorName)
        {
            return db.Movies
                     .Where(m => m.DirectorName == directorName)
                     .ToList();
        }
    }
}