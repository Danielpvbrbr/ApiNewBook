using ApiNewBook.DTOs;
using ApiNewBook.Model;
using ApiNewBook.Repository.BookRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewBook.Controllers;

[Route("[controller]")]
[ApiController]

public class BookController : ControllerBase
{
    private readonly IBookRepository _repository;

    public BookController(IBookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _repository.GetBooks());
    }

    [HttpGet("getById/{id:int:min(1)}", Name = "GetBook")]
    public async Task<ActionResult> GetById(int id)
    {
        var book = await _repository.GetByIdBook(id);

        if(book is null) {
            return NotFound($"Livro com do id {id} Não encontrado");
        }

        return Ok(book);
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<ActionResult> Post(BookDTOCreate bookDTOCreate)
    {
        var bookCreate = await _repository.PostBook(bookDTOCreate);

        if (bookCreate is null)
        {
            return BadRequest("Erro ao salvar os dados no banco");
        }

        // return new CreatedAtRouteResult("GetBook", new { id = bookCreate.id }, bookCreate);
        return Ok(bookCreate);
    }

    [HttpPut("update/{id:int:min(1)}")]
    [Authorize]
    public async Task<ActionResult> Update(int id, BookDTO bookDTO)
    {
        if (bookDTO.id != id)
        {
            return NotFound($"Livro com do id {id} Não encontrado");
        }

       var bookCreate =  await _repository.Update(bookDTO);

        return Ok(bookCreate);
    }

    [HttpDelete("remove/{id:int:min(1)}")]
    //[Authorize]
    public async Task<ActionResult> Delete(int id) {

        var book = await _repository.GetByIdBook(id);

        if (book is null)
        {
            return NotFound($"Livro com do id {id} Não encontrado");
        }

        var bookDeleted = await _repository.Delete(id);

        return Ok(bookDeleted);
    }
}
