using ApiNewBook.DTOs;
using ApiNewBook.Model;
using ApiNewBook.Repository.LanguageRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _repository;

        public LanguageController(ILanguageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _repository.Get());
        }

        [HttpGet("getById/{id:int:min(1)}",Name = "GetLanguages")]
        public async Task<ActionResult> GetByIdLanguages(int id)
        {
            var languages = await _repository.GetById(id);

            if (languages is null)
            {
                return NotFound($"Categoria com do id {id} Não encontrado");
            }

            return Ok(languages);
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult> Post(LanguageDTO languageDTO)
        {

            var languageCreate = await _repository.Post(languageDTO);

            if (languageCreate is null)
            {
                return BadRequest("Erro ao savar dados no banco..");
            }

            //return new CreatedAtRouteResult("GetLanguages", new {name = languageDTO.name}, languageDTO);
            return Ok(languageDTO);
        }

        [HttpPut("update/{id:int:min(1)}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, Language languageDTO)
        {

            if (id != languageDTO.id)
            {
                return BadRequest($"Categoria com do id {id} Não encontrado");
            }

             await _repository.Update(languageDTO);

            return Ok(languageDTO);
        }

        [HttpDelete("remove/{id:int:min(1)}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var language = await _repository.GetById(id);

            if (language is null)
            {
                return NotFound($"Categoria com do id {id} Não encontrado");
            }

            var languagesDeleted = await _repository.Delete(id);

            return Ok(languagesDeleted);
        }
    }
}
