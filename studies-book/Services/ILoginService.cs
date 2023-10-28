using studies_book.Entities;
using studies_book.Models;

namespace studies_book.Services
{
    public interface ILoginService
    {
        User Login(LoginDto loginDto);
    }
}