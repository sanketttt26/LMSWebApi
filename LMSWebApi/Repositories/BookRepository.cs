using LMSWebApi.Models;

namespace LMSWebApi.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> _books = new List<Book>();
        public IEnumerable<Book> GetAllBooks() => _books;
        public Book GetBookByISBN(string isbn) => _books.FirstOrDefault(b => b.ISBN == isbn);
        public IEnumerable<Book> GetBooksByTitle(string title) =>
            _books.Where(b => b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase));
        public void AddBook(Book book) => _books.Add(book);

        public void UpdateBook(string isbn, Book updatedBook)
        {
            var existingBook = GetBookByISBN(isbn);
            if (existingBook != null)
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.Available = updatedBook.Available;
            }
        }
        public void RemoveBook(string isbn)
        {
            var book = GetBookByISBN(isbn);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
