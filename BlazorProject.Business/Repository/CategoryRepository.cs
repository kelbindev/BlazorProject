using AutoMapper;
using BlazorProject.Business.Interface;
using BlazorProject.DataAccess;
using BlazorProject.DataAccess.Data;
using BlazorProject.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<CategoryDto, Category>(categoryDto);
            category.CreatedDate = DateTime.Now;
            _context.Add(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Category category = _context.Category.FirstOrDefault(u => u.Id == id);
            if (category != null)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var categories = await _context.Category.ToListAsync();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (category != null)
            {
                return _mapper.Map<Category, CategoryDto>(category);
            }
            return new CategoryDto();
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            Category category = await _context.Category.FirstOrDefaultAsync(u => u.Id == categoryDto.Id);

            if (category != null)
            {
                category.Name = categoryDto.Name;

                _context.Update(category);
                await _context.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDto>(category);
            }
            return new CategoryDto();
        }
    }
}
