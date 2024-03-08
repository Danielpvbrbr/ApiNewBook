using ApiNewBook.Contexts;
using ApiNewBook.Model;
using ApiNewBook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Repository
{
    public class CategoryRepositories : ICategoryRepository
    {
        public readonly AppDbContext _context;

        public CategoryRepositories(AppDbContext context) 
        {
            _context = context;
        }   

        public IEnumerable<Category> GetCategory()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public Category GetByIdCategory(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.id == id);
        }

        public Category PostCategory(Category category)
        {
            //if (category is null)
            //{
            //    throw new ArgumentNullException(nameof(category));
            //}
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;

        }

        public Category Update(Category category)
        {
            //if(category is null)
            //{
            //    throw new ArgumentNullException(nameof(category));
            //}

            _context.Categories.Update(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            var category = _context.Categories.Find(id);
            //if (category is null)
            //{
            //    throw new ArgumentNullException(nameof(category));
            //}
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}
