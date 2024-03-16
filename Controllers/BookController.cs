using ApiNewBook.Model;
using ApiNewBook.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewBook.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BookController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Book>> Get()
    {
        return Ok(_repository.GetBooks());
    }

    [HttpGet("{id:int:min(1)}", Name = "GetBook")]
    public ActionResult<Book> GetById(int id)
    {
        var book = _repository.GetByIdBook(id);

        if(book is null) {
            return NotFound($"Livro com do id {id} Não encontrado");
        }

        return Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> Post(Book book)
    {
        var bookCreate = _repository.PostBook(book);

        if (bookCreate is null)
        {
            return BadRequest("Erro ao salvar os dados no banco");
        }

        return new CreatedAtRouteResult("GetBook", 
            new { id = bookCreate.id }, bookCreate);
    }

    [HttpPut("{id:int:min(1)}")]
    public ActionResult<Book> Update(int id, Book book)
    {
        if (id != book.id)
        {
            return NotFound($"Produto com do id {id} Não encontrado");
        }
        _repository.Update(book);
        return Ok(book);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult<Book> Delete(int id) {

        var book = _repository.Delete(id);
        if (book is null)
        {
            return BadRequest("Erro ao deletar o dados no banco");
        }
        var bookDeleted = _repository.Delete(id);
        return Ok(bookDeleted);
    }
}
