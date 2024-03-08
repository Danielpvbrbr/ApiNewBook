using ApiNewBook.Model;
using ApiNewBook.Repository.Interfaces;
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

        [HttpGet]
        public ActionResult<Language> Get()
        {
            return Ok(_repository.GetLanguages());
        }

        [HttpGet("{id:int:min(1)}",Name = "GetLanguages")]
        public ActionResult<Language> GetByIdLanguages(int id)
        {
            var languages = _repository.GetByIdLanguage(id);

            if (languages is null)
            {
                return NotFound($"Categoria com do id {id} Não encontrado");
            }

            return Ok(languages);
        }

        [HttpPost]
        public ActionResult<Language> Post(Language language)
        {
            var languageCreate = _repository.PostLanguage(language);

            if (languageCreate is null)
            {
                return BadRequest("Erro ao savar dados no banco..");
            }

            return new CreatedAtRouteResult("GetLanguages", new {id = languageCreate.id}, languageCreate);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Language> Put(int id, Language language)
        {
            if (language.id != id)
            {
                return NotFound($"Categoria com do id {id} Não encontrado");
            }
            var languagesDeleted = _repository.Update(language);
            return Ok(languagesDeleted);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Language> Delete(int id)
        {
            var language = _repository.GetByIdLanguage(id);

            if (language is null)
            {
                return NotFound($"Categoria com do id {id} Não encontrado");
            }
            var languagesDeleted = _repository.Delete(id);
            return Ok(languagesDeleted);
        }
    }
}
