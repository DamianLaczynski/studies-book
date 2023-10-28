using studies_book.Entities;

namespace studies_book.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}