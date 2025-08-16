using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Dtos
{
    public class UpdateAuthorRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "UserName cannot be over 10 characters")]
        public String UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "SurName cannot be over 10 characters")]
        public String SurName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Range(5, 50)]
        public int BooksPublished { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateOnly), "1900-01-01", "2100-12-31", ErrorMessage = "Birth date must be between 1900 and 2100.")]
        public DateOnly BirthDate { get; set; }

    }
}