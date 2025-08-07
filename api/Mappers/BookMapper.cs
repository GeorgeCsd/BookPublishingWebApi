using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Content = book.Content,
                Price = book.Price,
                CreatedOn = book.CreatedOn,
                AuthorId = book.AuthorId
            };
        }

        public static Book ToBookFromCreate(this BookRequestDto bookRequestDto, int authorId)
        {
            return new Book
            {
                Title = bookRequestDto.Title,
                Content = bookRequestDto.Content,
                Price = bookRequestDto.Price,
                AuthorId = authorId
            };
        }
        
        public static Book ToBookFromUpdate(this BookRequestDto bookRequestDto){
            return new Book
            {
                Title = bookRequestDto.Title,
                Content = bookRequestDto.Content,
                Price = bookRequestDto.Price
            };
        }
    }
}