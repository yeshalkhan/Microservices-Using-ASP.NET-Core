using Microsoft.AspNetCore.Mvc;
using BookstoreMicroservice.Models;
using BookstoreMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace BookstoreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookRepository _BookRepository;

        public BookController(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Books = _BookRepository.GetAllBooks();
            return new OkObjectResult(Books);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var Book = _BookRepository.GetBookByID(id);
            return new OkObjectResult(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            using (var scope = new TransactionScope())
            {
                _BookRepository.AddBook(Book);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Book.Id }, Book);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book Book)
        {
            if (Book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _BookRepository.UpdateBook(Book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _BookRepository.DeleteBook(id);
            return new OkResult();
        }
    }
}