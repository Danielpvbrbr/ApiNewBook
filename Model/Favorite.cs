using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiNewBook.Model
{
    [Table("favorite")]
    public class Favorite
    {
        [Key]
        public int id { get; set; }

        public string title { get; set; }

        [EmailAddress]
        public string userEmail { get; set; }

        public int bookId { get; set; }
        [JsonIgnore]
        public Book? Book { get; set; }
    }
}
