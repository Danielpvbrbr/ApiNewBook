using ApiNewBook.Contexts;
using ApiNewBook.Model;
using ApiNewBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Repository
{
    public class BookRepositories : IBookRepository
    {
        public readonly AppDbContext _context;

        public BookRepositories(AppDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.AsNoTracking().ToList();
        }

        public Book GetByIdBook(int id)
        {
            return _context.Books.FirstOrDefault(x => x.id == id);
        }

        public Book PostBook(Book book)
        {
            //if (book is null)
            //{
            //    throw new ArgumentNullException(nameof(book));
            //}
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public Book Update(Book book)
        {
            //if (book is null)
            //{
            //    throw new ArgumentNullException(nameof(book));
            //}
            _context.Books.Update(book).State = EntityState.Modified;
            _context.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
            var books = _context.Books.Find(id);

            //if (books is null)
            //{
            //    throw new ArgumentNullException(nameof(books));
            //}
            _context.Books.Remove(books);
            _context.SaveChanges();
            return books;
        }
    }
}
