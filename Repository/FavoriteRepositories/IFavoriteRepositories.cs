using ApiNewBook.DTOs;
using ApiNewBook.Model;

namespace ApiNewBook.Repository.FavoriteRepositories
{
    public interface IFavoriteRepositories
    {
        Task<IEnumerable<Favorite>> GetAll();
        Task<Favorite> GetbyId(int id);
        Task<FavoriteDTO> Post(FavoriteDTO favoriteDTO);
        Task<Favorite> Delete(int id);
    }
}
