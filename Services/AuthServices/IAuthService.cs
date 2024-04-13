using ApiNewBook.DTOs;
using ApiNewBook.Model;

namespace ApiNewBook.Services.AuthServices
{
    public interface IAuthService
    {
        Task<Response<string>> Register(UsersCreateDTO usersCreateDTO);
        Task<Response<string>> Login(UsersLoginDTO usersLoginDTO);
    }
}
