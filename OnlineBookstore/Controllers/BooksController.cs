using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.DTO;
using OnlineBookstore.Services;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;


        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();

            if (books == null)
            {
                return BadRequest("No books found.");
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var book = await _bookService.Get(id);

            if (book == null)
            {
                return NotFound("Book doesn't exist!");
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookDTO book)
        {
            if (book == null)
            {
                return BadRequest("The book can't be null!");
            }

            if (await _bookService.Exists(book.Title,book.Author, -1))
            {
                return BadRequest("There is already a book with the same title and author.");
            }

            if (await _bookService.Add(book))
            {
                return Ok(book);
            }
            return BadRequest("The book was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] BookDTO bookDTO)
        {
            if (!await _bookService.Exists(id))
            {
                return BadRequest("There is no book with that id.");
            }
            if (await _bookService.Exists(bookDTO.Title,bookDTO.Author, id))
            {
                return BadRequest("There is already a book with the same title and author.");
            }

            if (await _bookService.Update(bookDTO, id))
            {
                return Ok(bookDTO);
            }
            return BadRequest("Invalid book!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _bookService.GetAll() == null)
            {
                return BadRequest("No books found.");
            }

            if (await _bookService.Get(id) == null)
            {
                return NotFound("The book doesn't exist!");
            }

            if (await _bookService.Delete(id))
            {
                return Ok("The book was successfully deleted!");
            }
            return BadRequest("Id invalid!");
        }
    }
}
