using ApiNewBook.DTOs;
using ApiNewBook.Model;

namespace ApiNewBook.Repository.LanguageRepositories
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> Get();
        Task<Language> GetById(int id);
        Task<LanguageDTO> Post(LanguageDTO languageDTO);
        Task<Language> Update(Language language);
        Task<Language> Delete(int id);
    }
}
