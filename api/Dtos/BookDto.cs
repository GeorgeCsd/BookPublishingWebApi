using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Price{ get; set; }
        public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int? AuthorId { get; set; }
    }
}