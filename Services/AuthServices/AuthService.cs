using ApiNewBook.Contexts;
using ApiNewBook.DTOs;
using ApiNewBook.Model;
using ApiNewBook.Services.AuthServices;
using ApiNewBook.Services.PasswordService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;

        public AuthService(AppDbContext context, IPasswordService passwordService, IMapper mapper)
        {
            _context = context;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Register(UsersCreateDTO usersCreateDTO)
        {
            Response<string> response = new Response<string>();

            try
            {
                if (!VerifyExistEmailIsUsers(usersCreateDTO))
                {
                    response.Data = null;
                    response.Status = false;
                    response.Message = "Email/Usuário já cadastrado!";
                }

                _passwordService.CreatePasswordHash(usersCreateDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                UserAuth users = new UserAuth()
                {
                    User = usersCreateDTO.User,
                    Email = usersCreateDTO.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                _context.Add(users);
                await _context.SaveChangesAsync();

                var isUsers = await _context.UserAuths.FirstOrDefaultAsync(x => x.Email == usersCreateDTO.Email);

                var token = _passwordService.CreateToken(isUsers!);

                response.Data = token;
                response.Message = "Usuário criado com sucesso!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> Login(UsersLoginDTO usersLoginDTO)
        {
            Response<string> response = new Response<string>();

            try
            {
                var users = await _context.UserAuths.FirstOrDefaultAsync(x => x.Email == usersLoginDTO.Email);

                if (users is null)
                {
                    response.Message = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                if (!_passwordService.VerifyPasswordHash(usersLoginDTO.Password, users.PasswordHash, users.PasswordSalt))
                {
                    response.Message = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }

                var token = _passwordService.CreateToken(users);

                response.Data = token;
                response.Message = "Usuário autenticado com sucesso!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;

        }

        public bool VerifyExistEmailIsUsers(UsersCreateDTO usersCreateDTO)
        {
            var user = _context.UserAuths.FirstOrDefault(x => x.Email == usersCreateDTO.Email || x.User == usersCreateDTO.User);

            if (user != null) return false;

            return true;
        }
    }
}
