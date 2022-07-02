using AutoMapper;
using BlazorProject.Business.Interface;
using BlazorProject.DataAccess;
using BlazorProject.DataAccess.Data;
using BlazorProject.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ProductDto> CreateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(u => u.Id == id);
            if (product != null)
            {
                _context.ChangeTracker.Clear();
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            var products = await _context.Product.Include(u=>u.Category).ToListAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _context.Product.Include(p=>p.Category).FirstOrDefaultAsync(u => u.Id == id);
            if (product != null)
            {
                return _mapper.Map<Product, ProductDto>(product);
            }
            return new ProductDto();
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            Product product = await _context.Product.FirstOrDefaultAsync(u => u.Id == productDto.Id);

            if (product != null)
            {
                product = _mapper.Map<ProductDto, Product>(productDto);
                _context.ChangeTracker.Clear();
                _context.Update(product);
                await _context.SaveChangesAsync();
                return productDto;
            }
            return new ProductDto();
        }
    }
}
