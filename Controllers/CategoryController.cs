using ApiNewBook.Model;
using ApiNewBook.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewBook.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _repository;

    public CategoryController(ICategoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<Category> Get()
    {
        return Ok(_repository.GetCategory());
    }

    [HttpGet("{id:int:min(1)}", Name = "GetCategory")]
    public ActionResult<Category> GetById(int id)
    {
        var category = _repository.GetByIdCategory(id);
        if (category is null)
        {
            return NotFound($"Categoria com do id {id} Não encontrado");
        } 

        return Ok(category);
    }

    [HttpPost]
    public ActionResult<Category> Post(Category category)
    {
        var categoryCreate = _repository.PostCategory(category);
        if (categoryCreate is null)
        {
            return BadRequest("Erro ao salvar os dados no banco");
        }
        return new CreatedAtRouteResult("GetCategory",
            new { id = categoryCreate.id }, categoryCreate);
    }

    [HttpPut("{id:int:min(1)}")]
    public ActionResult<Category> Put(int id, Category category)
    {
        if (category.id != id)
        {
            return NotFound($"Categoria com do id {id} Não encontrado");
        }

        var categoryCreate = _repository.Update(category);
        return Ok(categoryCreate);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult<Category> Delete(int id) {
        var category = _repository.GetByIdCategory(id);

        if (category is null)
        {
            return NotFound($"Categoria com do id {id} Não encontrado");
        }
        var categoryDelected = _repository.Delete(id);
        return Ok(categoryDelected);

    }

}
