using System.ComponentModel.DataAnnotations;

namespace studies_book.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "This field is required.")]
        [EmailAddress]
        [MinLength(3)]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5)]
        public string Password { get; set; }
    }
}