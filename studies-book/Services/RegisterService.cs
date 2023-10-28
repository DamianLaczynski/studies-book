using Microsoft.AspNetCore.Identity;
using studies_book.Entities;
using studies_book.Models;

namespace studies_book.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ILogger<RegisterService> _logger;

        public RegisterService(AppDbContext context, IPasswordHasher<User> passwordHasher, ILogger<RegisterService> logger)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public void Register(RegisterDto registerDto)
        {
            //Create new user object from dto
            var newContact = new User()
            {
                Email = registerDto.Email,
                Firstname = registerDto.Firstname,
                Surname = registerDto.Surname
            };

            //Hash password and save user
            var hashedPassword = _passwordHasher.HashPassword(newContact, registerDto.Password);
            newContact.HashedPassword = hashedPassword;
            _context.Users.Add(newContact);
            _context.SaveChanges();
            
        }
    }
}
