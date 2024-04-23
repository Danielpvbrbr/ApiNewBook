using ApiNewBook.Contexts;
using ApiNewBook.DTOs;
using ApiNewBook.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiNewBook.Repository.CategoryRepositories
{
    public class CategoryRepositories : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepositories(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return  await _context.Categories.AsNoTracking().ToListAsync();
        }

       public async Task<Category> GetById(int id)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<CategoryDTO> Post(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return categoryDTO;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category!);
            await _context.SaveChangesAsync();

            return category!;
        }
    }
}
