using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.DTOs
{
    public class UsersCreateDTO
    {
        [Required(ErrorMessage = "O campo User e obrigatório!")]
        public string User { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha e obrigatório!")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage = "Senhas não coincidem!")]
        public string ConfirmPassword { get; set; }
    }
}
