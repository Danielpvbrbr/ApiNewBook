using ApiNewBook.Model;

namespace ApiNewBook.Services.PasswordService
{
    public interface IPasswordService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(UserAuth users);
    }
}
