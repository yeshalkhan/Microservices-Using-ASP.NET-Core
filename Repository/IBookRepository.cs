using BookstoreMicroservice.Models;

namespace BookstoreMicroservice.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookByID(int BookId);
        void AddBook(Book Book);
        void DeleteBook(int BookId);
        void UpdateBook(Book Book);
        void Save();
    }
}
