using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Price{ get; set; }
        public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int? AuthorId { get; set; }
        public Author? Author{ get; set; }

    }
}