using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNewBook.Model
{
    [Table("language")]
    public class Language
    {

        [Key]
        public int id { get; set; }

        [StringLength(20, ErrorMessage = "O máximo de caracteres permitido e 20")]
        public string name { get; set; }

        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }
    }
}
