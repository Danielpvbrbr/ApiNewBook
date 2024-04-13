using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.DTOs
{
    public class UsersLoginDTO
    {
        [Required(ErrorMessage = "O campo E-mail e obrigatório."), EmailAddress(ErrorMessage = "O formato do e-mail esta inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha e obrigatório.")]
        public string Password { get; set; }
    }
}
