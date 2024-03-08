using ApiNewBook.Model;

namespace ApiNewBook.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategory();
        Category GetByIdCategory(int id);
        Category PostCategory(Category category);
        Category Update(Category category);
        Category Delete(int id);

    }
}
