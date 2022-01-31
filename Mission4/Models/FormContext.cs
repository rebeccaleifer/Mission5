using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class FormContext : DbContext
    {
        public FormContext(DbContextOptions<FormContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }


        // seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName= "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    CategoryId = 7,
                    Title = "Avatar the Last Airbender",
                    Year = 2005,
                    Director = "Dave Filoni",
                    Rating = "G",
                    Edited = false,
                    LentTo = "John",
                    Notes = "Uncle Iroh is the best"
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    Year = 2004,
                    Director = "Alfonso Cuaron",
                    Rating = "PG",
                    Edited = true,
                    LentTo = "Dustin",
                    Notes = "Harry Potter 3"

                },
                new ApplicationResponse
                {
                    MovieId = 3,
                    CategoryId = 4,
                    Title = "White Christmas",
                    Year = 1954,
                    Director = "Michael Curtiz",
                    Rating = "G",
                    Edited = false,
                    LentTo = "Jackson",
                    Notes = "Best Christmas movie"

                }
            );
        }
    }
}
