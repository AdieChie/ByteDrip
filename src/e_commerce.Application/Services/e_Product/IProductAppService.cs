using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Product
{
    public interface IProductAppService : IApplicationService
    {
        Task<ProductDto> CreateAsync(ProductDto input);
        Task<ProductDto> UpdateAsync(ProductDto input);
        Task<List<ProductDto>> GetAllAsync(int input);
        Task<List<ProductDto>> GetBySearch(string term);
        Task<List<ProductDto>> GetByBrands(string term);
        Task<List<ProductDto>> GetByCategory(string term);
        Task<List<ProductDto>> GetByFilter(string term , decimal minPrice ,decimal maxPrice);
        Task<ProductDto> GetAsync(Guid id);
        Task Delete(Guid id);
       
    }
}
