using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.DTO;
using OnlineBookstore.Services;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookStoreController : Controller
    {
        private readonly IBookStoreService _bookStoreService;

        public BookStoreController(IBookStoreService bookStoreService)
        {
            _bookStoreService = bookStoreService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookStores = await _bookStoreService.GetAll();

            if (bookStores == null)
            {
                return BadRequest("No BookStores found.");
            }

            return Ok(bookStores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var bookStore = await _bookStoreService.Get(id);

            if (bookStore == null)
            {
                return NotFound("The BookStore doesn't exist!");
            }

            return Ok(bookStore);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookStoreDTO bookStore)
        {
            if (bookStore == null)
            {
                return BadRequest("The BookStore can't be null!");
            }

            if (await _bookStoreService.Exists(bookStore.Name, -1))
            {
                return BadRequest("There is already a BookStore with that name.");
            }

            if (await _bookStoreService.Add(bookStore))
            {
                return Ok(bookStore);
            }
            return BadRequest("The BookStore was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] BookStoreDTO bookStore)
        {
            if (!await _bookStoreService.Exists(id))
            {
                return BadRequest("There is no BookStore with that id.");
            }
            if (await _bookStoreService.Exists(bookStore.Name, id))
            {
                return BadRequest("There is already a BookStore with that name.");
            }

            if (await _bookStoreService.Update(bookStore, id))
            {
                return Ok(bookStore);
            }
            return BadRequest("Invalid BookStore!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _bookStoreService.GetAll() == null)
            {
                return BadRequest("No BookStore found.");
            }

            if (await _bookStoreService.Get(id) == null)
            {
                return NotFound("The BookStore doesn't exist!");
            }

            if (await _bookStoreService.Delete(id))
            {
                return Ok("The BookStore was successfully deleted!");
            }
            return BadRequest("Invalid id!");
        }
    }
}
