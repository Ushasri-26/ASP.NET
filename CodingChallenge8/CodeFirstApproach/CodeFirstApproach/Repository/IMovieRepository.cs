using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstApproach.Models;
namespace CodeFirstApproach.Repository
{
    internal interface IMovieRepository
    {
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Movie> GetMoviesByYear(int year);
        IEnumerable<Movie> GetMoviesByDirector(string directorName);
    }
}
