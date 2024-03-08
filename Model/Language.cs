using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace ApiNewBook.Model
{
    [Table("language")]
    public class Language
    {
        public Language()
        {
            Books = new List<Book>();
        }

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório")]
        [StringLength(20, ErrorMessage = "O máximo de caracteres permitido e 20")]
        public string? name { get; set; }

        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
