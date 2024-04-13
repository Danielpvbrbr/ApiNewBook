using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.DTOs
{
    public class LanguageDTO
    {
        [Required(ErrorMessage = "O campo e obrigatório!")]
        public string name { get; set; }
    }
}
