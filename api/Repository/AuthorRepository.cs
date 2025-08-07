using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookPublishingDBContext dBContext;

        public AuthorRepository(BookPublishingDBContext bookPublishingDBContext)
        {
            dBContext = bookPublishingDBContext;
        }
        public Task<bool> AuthorExists(int id)
        {
            return dBContext.Authors.AnyAsync(a => a.Id == id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await dBContext.Authors.AddAsync(author);
            await dBContext.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> DeleteAsync(int id)
        {
            var authorObject = await dBContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (authorObject == null)
            {
                return null;
            }

            dBContext.Authors.Remove(authorObject);
            await dBContext.SaveChangesAsync();
            return authorObject;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await dBContext.Authors.Include(b => b.Books).ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await dBContext.Authors.Include(b => b.Books).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto authorDto)
        {
            var existingAuthor = await dBContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (existingAuthor == null)
            {
                return null;
            }

            existingAuthor.UserName = authorDto.UserName;
            existingAuthor.SurName = authorDto.SurName;
            existingAuthor.BooksPublished = authorDto.BooksPublished;
            existingAuthor.BirthDate = authorDto.BirthDate;

            await dBContext.SaveChangesAsync();
            return existingAuthor;
        }
    }
}