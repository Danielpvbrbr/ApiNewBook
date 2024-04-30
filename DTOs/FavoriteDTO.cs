
using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.DTOs;

public class FavoriteDTO
{
    [Required(ErrorMessage = "O campo e obrigatório!")]
    public string title { get; set; }

    public int bookId { get; set; }

    [EmailAddress]
    [Required]
    public string userEmail { get; set; }

}