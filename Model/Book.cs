using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNewBook.Model
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório")]
        [StringLength(40,ErrorMessage = "O máximo de caracteres permitido e 40")]
        public string? title { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório") ]
        [StringLength(600, ErrorMessage = "O máximo de caracteres permitido e 600")]
        public string? description { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório")]
        [StringLength(300, ErrorMessage = "O máximo de caracteres permitido e 300")]
        public string? caseUrl { get; set; }

        public int pages { get; set; }

        [StringLength(300, ErrorMessage = "O máximo de caracteres permitido e 300")]
        public string? pdfUrl { get; set; }

        public DateTime dateCreate { get; set; }

        [StringLength(40, ErrorMessage = "O máximo de caracteres permitido e 40")]
        public string? publishingCompany { get; set; }

        [StringLength(40, ErrorMessage = "O máximo de caracteres permitido e 40")]
        public string? sentByName { get; set; }

        public int year { get; set; }

        public int categoryId { get; set; }
        public int languageId { get; set; }

        [JsonIgnore]
        public Language? Languages { get; set; }

        [JsonIgnore]
        public Category? Categories { get; set; }

    }
}
