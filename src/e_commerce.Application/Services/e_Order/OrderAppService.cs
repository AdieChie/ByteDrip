using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using e_commerce.Domain;
using e_commerce.Dtos;
using e_commerce.Services.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Order
{
    [AbpAuthorize]
    public class OrderAppService : ApplicationService, IOrderAppService
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<OrderItem, Guid> _orderItemRepository;

        public OrderAppService(IRepository<Order, Guid> orderRepository, IRepository<Customer, Guid> customerRepository, IRepository<OrderItem, Guid> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<OrderDto> CreateAsync(OrderDto input)
        {
            var order = ObjectMapper.Map<Order>(input);
            order.Customer = await _customerRepository.GetAsync(input.CustomerId);
            order.OrderNumber = Util.GenerateOrderNum();
            var orderEntity =await _orderRepository.InsertAsync(order);
            CurrentUnitOfWork.SaveChanges();
            foreach (var item in input.Items)
            {
                var OrderItemEntity = ObjectMapper.Map<OrderItem>(item);
                OrderItemEntity.Order = orderEntity;
                await _orderItemRepository.InsertAsync(OrderItemEntity);
            }

            return ObjectMapper.Map<OrderDto>(order);
        }

       

        public async Task<List<ResponeDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var orders = await _orderRepository.GetAllIncluding(m => m.Customer).ToListAsync();
            return ObjectMapper.Map<List<ResponeDto>>(orders);
        }

        public async Task<PagedResultDto<ResponeDto>> GetByCustomerId(Guid id)
        {

            var filtered = _orderRepository.GetAllIncluding(c => c.Customer).Where(e => e.Customer.Id == id);
            var result = new PagedResultDto<ResponeDto>();
            result.Items = ObjectMapper.Map<IReadOnlyList<ResponeDto>>(filtered);
            return await Task.FromResult(result);
        }
        public async Task<OrderDto> GetAsync(Guid id)
        {
            var order = await _orderRepository.GetAllIncluding(m => m.Customer).FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
                throw new UserFriendlyException("Order not found!");
            return ObjectMapper.Map<OrderDto>(order);
        }

        public async  Task<OrderDto> UpdateAsync(UpdateDto input)
        {
            var order = _orderRepository.Get(input.Id);
            var updated = await _orderRepository.UpdateAsync(ObjectMapper.Map(input, order));
            return ObjectMapper.Map<OrderDto>(updated);
        }

        public async Task Delete(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
