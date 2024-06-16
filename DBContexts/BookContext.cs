using Microsoft.EntityFrameworkCore;
using BookstoreMicroservice.Models;

namespace BookstoreMicroservice.DBContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Horror",
                    Description = "Designed to frighten and thrill, often with supernatural elements.",
                },
                new Genre
                {
                    Id = 2,
                    Name = "Mystery",
                    Description = "Revolves around solving a crime or uncovering secrets.",
                },
                new Genre
                {
                    Id = 3,
                    Name = "Fiction",
                    Description = "Imaginative narratives not based on real events.",
                }
            );
        }
    }

}
