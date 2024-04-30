using ApiNewBook.DTOs;
using ApiNewBook.Model;
using ApiNewBook.Repository.CategoryRepositories;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("getAll")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _repository.Get());
    }

    [HttpGet("getById/{id:int:min(1)}", Name = "GetCategory")]
    public async Task<ActionResult> GetById(int id)
    {
        var category = await _repository.GetById(id);

        if (category is null) return NotFound($"Categoria com do id {id} Não encontrado"); 

        return Ok(category);
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<ActionResult> Post(CategoryDTO categoryDTO)
    {
        var categoryCreate =  await _repository.Post(categoryDTO);

        if (categoryCreate is null) return BadRequest("Erro ao salvar os dados no banco");

        return Ok(categoryDTO);

        //return new CreatedAtRouteResult("GetCategory",
        //    new { id = categoryCreate.id }, categoryCreate);
    }

    [HttpPut("update/{id:int:min(1)}")]
    [Authorize]
    public async Task<ActionResult> Put(int id, Category category)
    {
        if (category.id != id) return NotFound($"Categoria com do id {id} Não encontrado");

        var categoryCreate = await _repository.Update(category);

        return Ok(categoryCreate);
    }

    [HttpDelete("remove/{id:int:min(1)}")]
    [Authorize]
    public async Task<ActionResult> Delete(int id) {

        var category = await _repository.GetById(id);

        if (category is null) return NotFound($"Categoria com do id {id} Não encontrado");

        var categoryDelected = await _repository.Delete(id);

        return Ok(categoryDelected);
    }

}
