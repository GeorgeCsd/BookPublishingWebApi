using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Author
    {
        public int Id { get; set; }
        public String UserName { get; set; } = string.Empty;
        public String SurName { get; set; } = string.Empty;
        public String Email { get; set; } = string.Empty;
        public int BooksPublished { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}