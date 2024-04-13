using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNewBook.Model;
[Table("UserAuth")]
public class UserAuth
{
    public int Id { get; set; }

    public string User { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public DateTime TokenDateCreate { get; set; } = DateTime.Now;
}
