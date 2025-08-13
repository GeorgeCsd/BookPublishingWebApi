using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToAuthorDto(this Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                UserName = author.UserName,
                SurName = author.SurName,
                Email = author.Email,
                BooksPublished = author.BooksPublished,
                BirthDate = author.BirthDate,
                Books = author.Books.Select(x => x.ToBookDto()).ToList()
            };
        }

        public static Author ToAuthorFromCreateDto(this CreateAuthorRequestDto createAuthorRequestDto)
        {
            return new Author
            {
                UserName = createAuthorRequestDto.UserName,
                SurName = createAuthorRequestDto.SurName,
                Email = createAuthorRequestDto.Email,
                BooksPublished = createAuthorRequestDto.BooksPublished,
                BirthDate = createAuthorRequestDto.BirthDate
            };
        }

    }
}