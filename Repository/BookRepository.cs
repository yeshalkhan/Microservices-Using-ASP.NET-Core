using Microsoft.EntityFrameworkCore;
using BookstoreMicroservice.Models;
using BookstoreMicroservice.DBContexts;

namespace BookstoreMicroservice.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteBook(int BookId)
        {
            var Book = _dbContext.Books.Find(BookId);
            _dbContext.Books.Remove(Book);
            Save();
        }

        public Book GetBookByID(int BookId)
        {
            return _dbContext.Books.Find(BookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public void AddBook(Book Book)
        {
            _dbContext.Add(Book);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBook(Book Book)
        {
            _dbContext.Entry(Book).State = EntityState.Modified;
            Save();
        }
    }
}
