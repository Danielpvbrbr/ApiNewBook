using ApiNewBook.Model;

namespace ApiNewBook.Repository.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetByIdBook(int id);
        Book PostBook(Book book);
        Book Update(Book book);
        Book Delete(int id);
    }
}
