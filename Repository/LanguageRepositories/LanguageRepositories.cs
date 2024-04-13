using ApiNewBook.Contexts;
using ApiNewBook.DTOs;
using ApiNewBook.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Repository.LanguageRepositories
{
    public class LanguageRepositories : ILanguageRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LanguageRepositories(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Language>> Get()
        {
            return await _context.Languages.AsNoTracking().ToListAsync();
        }

        public async Task<Language> GetById(int id)
        {
            return await _context.Languages.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<LanguageDTO> Post(LanguageDTO languageDTO)
        {
            var language = _mapper.Map<Language>(languageDTO);

            await _context.Languages.AddAsync(language);
            await _context.SaveChangesAsync();

            return languageDTO;
        }

        public async Task<Language> Update(Language language)
        {
            _context.Languages.Update(language).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return language;
        }

        public async Task<Language> Delete(int id)
        {
            var language = await _context.Languages.FindAsync(id);

            _context.Languages.Remove(language!);
            await _context.SaveChangesAsync();

            return language!;
        }
    }
}
