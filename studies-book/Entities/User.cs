namespace studies_book.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(5)]
        [EmailAddress]
        public string Email { get; set; } 

        public string HashedPassword { get; set; }

        [MinLength(1)]
        [MaxLength(255)]
        public string Firstname { get; set; }

        [MinLength(1)]
        [MaxLength(255)]
        public string Surname { get; set; }
    }
}
