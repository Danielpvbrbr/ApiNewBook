using ApiNewBook.DTOs;
using ApiNewBook.Model;
using ApiNewBook.Repository.FavoriteRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewBook.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepositories _repository;

        public FavoriteController(IFavoriteRepositories repository) {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll()
        {
           return Ok(await _repository.GetAll());
        }

        [HttpGet("getById/{id:int:min(0)}",Name = "GetFavorite")]
        public async Task<ActionResult> Get(int id)
        {
            var favorite = await _repository.GetbyId(id);

            if(favorite is null) return NotFound($"Book Favorito com do id {id} Não encontrado");

            return Ok(favorite);
        }

        [HttpPost("add")]
        public async Task<ActionResult> Post(FavoriteDTO favoriteDTO)
        {
            var favoriteCreate = await _repository.Post(favoriteDTO);

            if(favoriteCreate is null) return BadRequest("Erro ao salvar dados ao banco!");

            return Ok(favoriteCreate);
        }

        [HttpDelete("remove/{id:int:min(1)}")]
        public async Task<ActionResult> Delete(int id)
        {
            var favorite = await _repository.GetbyId(id);

            if (favorite is null) return NotFound($"Book Favorito com do id {id} Não encontrado");
            var favoriteRemove = await _repository.Delete(id);

            return Ok(favoriteRemove);
        }
    }
}
