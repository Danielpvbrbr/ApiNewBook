using ApiNewBook.Contexts;
using ApiNewBook.Model;
using ApiNewBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Repository
{
    public class LanguageRepositories:ILanguageRepository
    {
        public readonly AppDbContext _context;

        public LanguageRepositories(AppDbContext context) 
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Languages.AsNoTracking().ToList();
        }

        public Language GetByIdLanguage(int id)
        {
            return _context.Languages.FirstOrDefault(x => x.id == id);
        }

        public Language PostLanguage(Language language)
        {
            //if (language is null)
            //{
            //    throw new ArgumentNullException(nameof(language));
            //}
            _context.Languages.Add(language);
            _context.SaveChanges();
            return language;

        }

        public Language Update(Language language)
        {
            //if (language is null)
            //{
            //    throw new ArgumentNullException(nameof (language));
            //}
            _context.Update(language).State = EntityState.Modified;
            _context.SaveChanges();
            return language;
        }

        public Language Delete(int id)
        {
            var language = _context.Languages.Find(id);
            //if (language is null)
            //{
            //    throw new ArgumentNullException(nameof(language));
            //}
            _context.Languages.Remove(language);
            _context.SaveChanges();
            return language;
        }
    }
}
