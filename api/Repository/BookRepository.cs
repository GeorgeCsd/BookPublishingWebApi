using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookPublishingDBContext dBContext;

        public BookRepository(BookPublishingDBContext bookPublishingDBContext)
        {
            dBContext = bookPublishingDBContext;
        }
        public async Task<Book> CreateAsync(Book book)
        {
            await dBContext.Books.AddAsync(book);
            await dBContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            var bookObject = await dBContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (bookObject == null)
            {
                return null;
            }

            dBContext.Books.Remove(bookObject);
            await dBContext.SaveChangesAsync();
            return bookObject;
        }


        public async Task<List<Book>> GetAllAsync()
        {
            return await dBContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await dBContext.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existingBook = await dBContext.Books.FindAsync(id);

            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Content = book.Content;
            existingBook.Price = book.Price;

            await dBContext.SaveChangesAsync();
            return existingBook;
        }
    }
}