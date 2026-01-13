using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstApproach.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDB")
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}