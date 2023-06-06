using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Order
{
   public interface IOrderAppService : IApplicationService
    {
        Task<OrderDto> CreateAsync(OrderDto input);
        Task<OrderDto> UpdateAsync(UpdateDto input);
        Task<List<ResponeDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
       /* Task<List<ResponeDto>> GetByCustomerId(Guid id);*/
        Task<OrderDto> GetAsync(Guid id);
        Task Delete(Guid id);
    }
}
