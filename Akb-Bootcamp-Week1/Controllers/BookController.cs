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
            // List of valid order parameters
            var orderReq = new List<string> { "name", "id", "price", "author" };

            // If no order parameter is provided, return the unsorted list of books
            if (order == null)
                return Ok(_bookService.GetBooks());
            else
            {
                // Check if the provided order parameter is valid
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
            // Retrieve the book by its ID from the book service
            var value = _bookService.GetBookById(id);
            // If the book is not found, return a 404 Not Found response
            if (value == null)
            { return NotFound(); }
            else
            // If the book is found, return a 200 OK response with the book details
            { return Ok(value); }

        }

        // POST  api/book
        // Endpoint to add a new book.
        [HttpPost]
        public IActionResult Post([FromBody] BookAddModel value)
        {
            // Create a new book instance with the provided data
            var book = new BookAddModel
            {
                Name = value.Name,
                Author = value.Author,
                Description = value.Description,
                Price = value.Price
            };
            // Add the new book using the book service and return a 200 OK response
            var createdBook = _bookService.AddBook(book);
            return CreatedAtAction(nameof(Get), new { id = createdBook.Id }, createdBook);

        }

        // PUT api/book/{id}
        // Endpoint to update an existing book by its ID.
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

