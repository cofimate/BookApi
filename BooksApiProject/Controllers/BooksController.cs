using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooksApiProject.Services;
using BooksApiProject.Models;

namespace BooksApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private  IBookRepository bookRepository;
        public BooksController(IBookRepository _bookRepository)
        {
            bookRepository = _bookRepository;
        }

        //api/Books
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = bookRepository.GetBooks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(books);
        }


        [HttpGet("{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Book))]
        public IActionResult GetBook(int bookId)
        {
            var book = bookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(book);
        }
    }
}