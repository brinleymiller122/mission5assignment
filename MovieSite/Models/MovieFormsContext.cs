using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Models
{
    public class MovieFormsContext : DbContext
    {
        public MovieFormsContext(DbContextOptions<MovieFormsContext> options) : base (options)
        {

        }

        public DbSet<MovieModel> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieModel>().HasData(
                new MovieModel
                {
                    MovieId = 1,
                    Title = "Free Guy",
                    Year = 2021,
                    Director = "Shawn Levy",
                    Rating = "PG",
                    Notes = "Ryan Reynolds is the best ever..."

                },
                new MovieModel
                {
                    MovieId = 2,
                    Title = "JoJo Rabbit",
                    Year = 2019,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Notes = "Powerful"
                },
                new MovieModel
                {
                    MovieId = 3,
                    Title = "Napoleon Dynamite",
                    Year = 2004,
                    Director = "Jared Hess",
                    Rating = "PG",
                    Notes = "Hilarious"
                }
                ) ;
        }
    }
}
