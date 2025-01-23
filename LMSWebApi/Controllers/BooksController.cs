using LMSWebApi.Models;
using LMSWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _repository = new BookRepository();

        //ENDPOINT FOR GETTING ALL THE BOOKS
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(_repository.GetAllBooks());
        }


        //ENDPOINT TO GET BOOK BY BOOK TITLE

        [HttpGet("{title}")]

        public ActionResult<IEnumerable<Book>> GetBooksByTitle(string title)
        {
            var books = _repository.GetBooksByTitle(title);
            if(books == null || !books.Any())
            {
                return NotFound("No books found with given title");
            }
            else
            {
                return Ok(books);

            }
        }

        //DELETE /api/books/{isbn}: Remove a book from the library using its ISBN. 
        [HttpDelete("{isbn}")]

        public ActionResult<IEnumerable<Book>> GetBookByIsbn(string isbn)
        {
            var book = _repository.GetBookByISBN(isbn);
            if(book == null)
            {
                return NotFound("Book with current ISBN doesnt exists!!!");
            }
            return Ok($"Book with ISBN {isbn} removed from the database");
        }


        //POST /api/books: Add a new book to the library. 

    }
}
