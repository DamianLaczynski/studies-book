using Microsoft.AspNetCore.Identity;
using studies_book.Entities;
using studies_book.Models;
using System.Security.Authentication;

namespace studies_book.Services
{
    public class LoginService : ILoginService
    {

        private readonly AppDbContext _context;

        private readonly IPasswordHasher<User> _passwordHasher;


        private readonly ILogger<LoginService> _logger;

        public LoginService(AppDbContext context, IPasswordHasher<User> passwordHasher, ILogger<LoginService> logger)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }


        public User Login(LoginDto loginDto)
        {
            //Check if user exists
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email);

            if (user is null)
                throw new InvalidCredentialException("Incorrect email or password");


            //Check if password is correct
            var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, loginDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                _logger.LogInformation($"Failed account login attempt. Email: {loginDto.Email}");
                throw new InvalidCredentialException("Incorrect email or password");
            }

            return user;
        }
    }
}
