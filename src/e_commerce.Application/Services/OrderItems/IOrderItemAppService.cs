using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.OrderItems
{
   public  interface IOrderItemAppService : IApplicationService
    {
        Task<OrderItemDto> CreateAsync(OrderItemDto input);
        Task<OrderItemDto> UpdateAsync(Guid id, OrderItemDto input);
        Task<List<OrderItemDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<OrderItemDto> GetAsync(Guid id);
        Task<List<OrderItemDto>> GetByOrderId(Guid id);
        Task Delete(Guid id);

    }
}
