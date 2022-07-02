using BlazorProject.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Business.Interface
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
        public Task<CategoryDto> UpdateCategory(CategoryDto categoryDto);
        public Task<bool> DeleteCategory(int id);
        public Task<CategoryDto> GetCategoryById(int id);
        public Task<IEnumerable<CategoryDto>> GetAllCategory();
    }
}
