using Akb_Bootcamp_Week1.Models;
using Akb_Bootcamp_Week1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Akb_Bootcamp_Week1.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/book?order={field}
        [HttpGet]
        public IActionResult Get([FromQuery] string? order)
        {
            var orderReq = new List<string> { "name", "id", "price", "author" };
            if (order == null)
                return Ok(_bookService.GetBooks());
            else
            {
                if (orderReq.Contains(order))
                    return Ok(_bookService.GetBooks(order));
                else
                    return BadRequest("Order parameter is not found.");
            }

        }

        // GET api/book/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _bookService.GetBookById(id);
            if (value == null)
            { return NotFound(); }
            else
            { return Ok(value); }

        }

        // POST api/book
        [HttpPost]
        public IActionResult Post([FromBody] BookModel value)
        {
            var book = new BookModel
            {
                Name = value.Name,
                Id = value.Id,
                Author = value.Author,
                Description = value.Description,
                Price = value.Price
            };
            _bookService.AddBook(book);
            return Ok(value);
        }

        // PUT api/book/{id}
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] BookModel value, int id)
        {
            if (_bookService.UpdateBook(value, id))
                return Ok();
            else
                return BadRequest();
        }


        // PATCH api/book/{id}
        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] BookUpdateModel value, int id)
        {
            if (_bookService.UpdateBookPatch(value, id))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE api/book/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_bookService.DeleteBook(id)) return Ok();
            else return NotFound();
        }

    }
}

