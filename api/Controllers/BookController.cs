using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepo;
        private readonly IAuthorRepository authorRepo;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            bookRepo = bookRepository;
            authorRepo = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingAndSortingParams parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var books = await bookRepo.GetAllAsync(parameters);

            var bookDto = books.Select(b => b.ToBookDto());

            return Ok(bookDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await bookRepo.GetByIdAsync(id);

            if (book == null)
                return NotFound();
            return Ok(book.ToBookDto());
        }

        [HttpPost("{authorId:int}")]
        public async Task<IActionResult> Create([FromRoute] int authorId, [FromBody] BookRequestDto bookRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await authorRepo.AuthorExists(authorId))
                return BadRequest("Author does not exist");

            var bookObject = bookRequestDto.ToBookFromCreate(authorId);
            await bookRepo.CreateAsync(bookObject);
            return CreatedAtAction(nameof(GetById), new { id = bookObject.Id }, bookObject.ToBookDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookRequestDto bookRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await bookRepo.UpdateAsync(id, bookRequestDto.ToBookFromUpdate());

            if (book == null)
                return NotFound("Book was not found");

            return Ok(book.ToBookDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookObject = await bookRepo.DeleteAsync(id);

            if (bookObject == null)
                return NotFound("Book was not found");

            return Ok(bookObject);
        }
    }
}