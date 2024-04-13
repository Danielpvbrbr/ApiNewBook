using ApiNewBook.Contexts;
using ApiNewBook.DTOs;
using ApiNewBook.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiNewBook.Repository.BookRepositories
{
    public class BookRepositories : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookRepositories(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByIdBook(int id)
        {
            return await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<BookDTOCreate> PostBook(BookDTOCreate bookDTOCreate)
        {
           var book = _mapper.Map<Book>(bookDTOCreate);

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return bookDTOCreate;
        }

        public async Task<BookDTO> Update(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            _context.Books.Update(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return bookDTO;
        }

        public async Task<Book> Delete(int id)
        {
            var books = await _context.Books.FindAsync(id);

            _context.Books.Remove(books!);
            await _context.SaveChangesAsync();

            return books!;
        }
    }
}
