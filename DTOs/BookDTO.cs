using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.DTOs
{
    public class BookDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório")]
        public string? title { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório")]
        public string? description { get; set; }

        [Required(ErrorMessage = "O campo e Obrigatório")]
        public string? caseUrl { get; set; }

        public int pages { get; set; }

        public string? pdfUrl { get; set; }

        public string? publishingCompany { get; set; }

        public string? sentByName { get; set; }

        public int year { get; set; }

        public int categoryId { get; set; }
        public int languageId { get; set; }

    }
}
