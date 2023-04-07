using BookstoreAPI.Models;
using BookstoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooksbyid([FromRoute]int id)
        {
            
            var book = await _bookRepository.GetBooksbyidAsync(id);
            if(book == null)
            {
                return NotFound();  
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> GetNewBook([FromBody]Book book)
        {
            var id = await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBooksbyid), new {id = id, Controller ="books"},id);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBook([FromBody] Book book, [FromRoute]int id)
        {
             await _bookRepository.UpdateBookAsync(id ,book);
             return Ok();
        }

        [HttpPatch("{id}")]

        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument book, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBook( [FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
