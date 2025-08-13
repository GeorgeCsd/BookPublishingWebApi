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
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase

    {
        private readonly BookPublishingDBContext dBContext;
        private readonly IAuthorRepository authorRepo;

        public AuthorController(BookPublishingDBContext bookPublishingDBContext, IAuthorRepository authorRepository)
        {
            dBContext = bookPublishingDBContext;
            authorRepo = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingAndSortingParams parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var authors = await authorRepo.GetAllAsync(parameters);
            var authorDto = authors.Select(a => a.ToAuthorDto());
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = await authorRepo.GetByIdAsync(id);
            if (author == null)
                return NotFound();
            return Ok(author.ToAuthorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequestDto createAuthor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var authorObject = createAuthor.ToAuthorFromCreateDto();
            await authorRepo.CreateAsync(authorObject);
            return CreatedAtAction(nameof(GetById), new { id = authorObject.Id }, authorObject.ToAuthorDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorRequestDto updateAuthor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var authorObject = await authorRepo.UpdateAsync(id, updateAuthor);
            if (authorObject == null)
                return NotFound();

            return Ok(authorObject.ToAuthorDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var authorObject = await authorRepo.DeleteAsync(id);
            if (authorObject == null)
                return NotFound();
            return NoContent();
        }
    }
}