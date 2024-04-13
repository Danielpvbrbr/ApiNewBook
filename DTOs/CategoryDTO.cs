using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.DTOs
{
    public class CategoryDTO
    {
        [Required(ErrorMessage = "O campo nome e obrigatório!")]
        public string name { get; set; }
    }
}
