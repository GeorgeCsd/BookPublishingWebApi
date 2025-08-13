using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Repository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync(PagingAndSortingParams parameters);

        Task<Author?> GetByIdAsync(int id);

        Task<Author> CreateAsync(Author author);

        Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto authorDto);

        Task<Author?> DeleteAsync(int id);

        Task<bool> AuthorExists(int id);
    }
}