using ApiNewBook.Model;

namespace ApiNewBook.Repository.Interfaces
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();
        Language GetByIdLanguage(int id);
        Language PostLanguage(Language language);
        Language Update(Language language);
        Language Delete(int id);
    }
}
