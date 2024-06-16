﻿namespace BookstoreMicroservice.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int GenreId { get; set; }
    }
}
