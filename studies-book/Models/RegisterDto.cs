using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace studies_book.Models
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required(ErrorMessage ="This field is required.")]
        [MinLength(3)]
        [MaxLength(320)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(5)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "This field is required.")]
        [Compare(nameof(Password), ErrorMessage = "Password don't match.")]
        [MinLength(5)]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [MinLength(1)]
        [MaxLength(255)]
        public string Firstname { get; set; }

        [MinLength(1)]
        [MaxLength(255)]
        [Required(ErrorMessage = "This field is required.")]
        public string Surname { get; set; }
    }
}