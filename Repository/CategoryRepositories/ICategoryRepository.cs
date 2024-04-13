using ApiNewBook.DTOs;
using ApiNewBook.Model;

namespace ApiNewBook.Repository.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> GetById(int id);
        Task<CategoryDTO> Post(CategoryDTO categoryDTO);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
    }
}
