using ApiNewBook.DTOs;
using ApiNewBook.Model;

namespace ApiNewBook.Repository.BookRepositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetByIdBook(int id);
        Task<BookDTOCreate> PostBook(BookDTOCreate bookDTOCreate);
        Task<BookDTO> Update(BookDTO bookDTO);
        Task<Book> Delete(int id);
    }
}
