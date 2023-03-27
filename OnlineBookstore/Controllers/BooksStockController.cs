using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.DTO;
using OnlineBookstore.Services;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksStockController : Controller
    {
        private readonly IBooksStockService _booksStockService;

        public BooksStockController(IBooksStockService booksStockService)
        {
            _booksStockService = booksStockService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var booksStocks = await _booksStockService.GetAll();

            if (booksStocks == null)
            {
                return BadRequest("No BooksStocks found.");
            }

            return Ok(booksStocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var booksStock = await _booksStockService.Get(id);

            if (booksStock == null)
            {
                return NotFound("BooksStock doesn't exist!");
            }

            return Ok(booksStock);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BooksStockDTO booksStock)
        {
            if (booksStock == null)
            {
                return BadRequest("The booksStock can't be null!");
            }

            if (!await _booksStockService.BookExists(booksStock.BookId))
            {
                return BadRequest("The book doesn't exist!");
            }

            if (!await _booksStockService.BookStoreExists(booksStock.BookStoreId))
            {
                return BadRequest("The bookStore doesn't exist!");
            }

            if (await _booksStockService.Add(booksStock))
            {
                return Ok(booksStock);
            }

            return BadRequest("The booksStock was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] BooksStockDTO booksStock)
        {
            if (!await _booksStockService.Exists(id))
            {
                return BadRequest("There is no booksStock with that id.");
            }

            if (!await _booksStockService.BookExists(booksStock.BookId))
            {
                return BadRequest("The book doesn't exist!");
            }

            if (!await _booksStockService.BookStoreExists(booksStock.BookStoreId))
            {
                return BadRequest("The bookStore doesn't exist!");

            }
            if (await _booksStockService.Update(booksStock, id))
            {
                return Ok(booksStock);
            }
            return BadRequest("Invalid booksStock!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _booksStockService.GetAll() == null)
            {
                return BadRequest("No booksStocks found.");
            }

            if (await _booksStockService.Get(id) == null)
            {
                return NotFound("BooksStock doesn't exist!");
            }

            if (await _booksStockService.Delete(id))
            {
                return Ok("BooksStock was successfully deleted!");
            }
            return BadRequest("Invalid id!");
        }
    }
}
