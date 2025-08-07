using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public String UserName { get; set; } = string.Empty;
        public String SurName { get; set; } = string.Empty;
        public int BooksPublished{ get; set; }
        public DateOnly BirthDate { get; set; }
        public List<BookDto> Books { get; set; }
    }
}