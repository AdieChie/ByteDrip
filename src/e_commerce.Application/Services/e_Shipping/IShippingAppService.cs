using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Shipping
{
   public interface IShippingAppService : IApplicationService
    {
        Task<ShippingDto> CreateAsync(ShippingDto input);
        Task<ShippingDto> UpdateAsync(Guid id, ShippingDto input);
        Task<List<ShippingDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<ShippingDto> GetAsync(Guid id);
        Task Delete(Guid id);
    }
}
