using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using e_commerce.Domain;
using e_commerce.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Product
{
    
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;

        public ProductAppService(IRepository<Product, Guid> productRepository, IRepository<Category, Guid> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductDto> CreateAsync(ProductDto input)
        {
            var product = ObjectMapper.Map<Product>(input);
            product.Category = await _categoryRepository.GetAsync(input.CategoryId);
            await _productRepository.InsertAsync(product);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<ProductDto>(product);
        }

        

        public async Task<List<ProductDto>> GetAllAsync(int input=100)
        {
            var products = await _productRepository.GetAllIncluding(c=> c.Category).ToListAsync();
            return ObjectMapper.Map<List<ProductDto>>(products.Take(input));
        }

        public async Task<List<ProductDto>> GetBySearch(string term)
        {

            var searchResult =  _productRepository.GetAllIncluding(c => c.Category).Where(e => e.Name.ToLower().Contains(term.ToLower())
            ||e.Brand.ToLower().Contains(term.ToLower())
            ||e.Category.Name.ToLower().Contains(term.ToLower()));
            var result = searchResult.Take(10);
            return ObjectMapper.Map<List<ProductDto>>(searchResult);
        }

        public async Task<List<ProductDto>> GetByCategory(string term)
        {

            var categoryResult = _productRepository.GetAllIncluding(c => c.Category).Where(e => e.Category.Name.ToLower()== term);
            var result = categoryResult.Take(10);
            return ObjectMapper.Map<List<ProductDto>>(categoryResult);
        }

        public async Task<List<ProductDto>> GetByBrands(string term)
        {

            var categoryResult = _productRepository.GetAllIncluding(c => c.Category).Where(e => e.Brand.ToLower().Contains(term.ToLower()));
           var result = categoryResult.Take(20);
            return ObjectMapper.Map<List<ProductDto>>(categoryResult);
        }

        public async Task<List<ProductDto>> GetByFilter(string term ,decimal minPrice ,decimal maxPrice)
        {
            
            var FilterResult = _productRepository.GetAllIncluding(c => c.Category)
                .Where(e => (e.Price >= minPrice && e.Price <= maxPrice && e.Category.Name.ToLower().Contains(term.ToLower())) || (e.Price >= minPrice && e.Price <= maxPrice && e.Brand.ToLower().Contains(term.ToLower())));
            var result = FilterResult.Take(20);
            return ObjectMapper.Map<List<ProductDto>>(FilterResult);
        }
        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAllIncluding(c => c.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                throw new UserFriendlyException("Product  not found!");
            return ObjectMapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto input)
        {
            var product = _productRepository.Get(input.Id);
            var updated = await _productRepository.UpdateAsync(ObjectMapper.Map(input, product));
            return ObjectMapper.Map<ProductDto>(updated);
        }

        public async Task Delete(Guid id)
        {

            await _productRepository.DeleteAsync(id);
        }
    }
}
