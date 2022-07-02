using BlazorProject.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Business.Interface
{
    public interface IProductRepository
    {
        public Task<ProductDto> CreateProduct(ProductDto productDto);
        public Task<ProductDto> UpdateProduct(ProductDto productDto);
        public Task<bool> DeleteProduct(int id);
        public Task<ProductDto> GetProductById(int id);
        public Task<IEnumerable<ProductDto>> GetAllProduct();
    }
}
