using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookApi.Models;
using BookApi.Services;

namespace BookApi.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
       

        private readonly ILogger<BookController> _logger;
        private IBookService _service;

        public BookController(ILogger<BookController> logger, IBookService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            IEnumerable<Book> list = _service.GetBooks();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        
        
        [HttpGet("{title}", Name="GetBook")]
        public IActionResult GetBookByTitle(string title)
        {
            Book obj = _service.GetBooksByTitle(title);
            if (obj!=null)
                return Ok(obj);
            return BadRequest();
        }

        /*[HttpGet("genre/")]
        public IActionResult GetBookByGenre(string genre)
        {
            Book obj = _service.GetBooksByGenre(genre);
            if (obj!=null)
                return Ok(obj);
            return BadRequest();
        }*/

        [HttpPost]
        public IActionResult CreateBook(Book b) {
            
            _service.CreateBook(b);
            //add some code to determine success
            return CreatedAtRoute("GetBook", new{title=b.Title}, b);

        }

        [HttpPut("{title}")]
        public IActionResult UpdateBook(string title, Book bookIn) {
            
            _service.UpdateBook(title, bookIn);
            
            return NoContent();
        }

        [HttpDelete("{title}")]
        public IActionResult DeleteBook(string title) {
            _service.DeleteBook(title);
            return NoContent();
        }
    }
}