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
        //set up tables
        public DbSet<MovieModel> Responses { get; set; }
        public DbSet<Category> Category { get; set; }

        //seeding the data 

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //seed majors
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Television" }
                );
            mb.Entity<MovieModel>().HasData(
                //Seed movies
                new MovieModel
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Free Guy",
                    Year = 2021,
                    Director = "Shawn Levy",
                    Rating = "PG",
                    Notes = "Ryan Reynolds is the best ever..."

                },
                new MovieModel
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "JoJo Rabbit",
                    Year = 2019,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Notes = "Powerful"
                },
                new MovieModel
                {
                    MovieId = 3,
                    CategoryId = 3,
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
