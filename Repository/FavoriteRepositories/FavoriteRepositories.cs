using ApiNewBook.Contexts;
using ApiNewBook.DTOs;
using ApiNewBook.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Repository.FavoriteRepositories
{
    public class FavoriteRepositories : IFavoriteRepositories
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteRepositories(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<IEnumerable<Favorite>> GetAll()
        {
            return await _context.Favorites.AsNoTracking().ToListAsync();
        }

        public async Task<Favorite> GetbyId(int id)
        {
            var favorite = await _context.Favorites.FirstOrDefaultAsync(x => x.id == id);

            return favorite!;
        }

        public async Task<FavoriteDTO> Post(FavoriteDTO favoriteDTO)
        {
            var favorite = _mapper.Map<Favorite>(favoriteDTO);
            await _context.Favorites.AddAsync(favorite);
            await _context.SaveChangesAsync();

            return favoriteDTO;
        }

        //public async Task<Favorite> Update(int id, Favorite favorite)
        //{
        //    _context.Favorites.Update(favorite).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return favorite;
        //}

        public async Task<Favorite> Delete(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);

            _context.Favorites.Remove(favorite!);
            await _context.SaveChangesAsync();

            return favorite!;
        }

    }
}
