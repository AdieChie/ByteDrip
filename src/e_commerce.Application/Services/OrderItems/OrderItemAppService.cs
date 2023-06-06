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

namespace e_commerce.Services.OrderItems
{
    [AbpAuthorize]
    public class OrderItemAppService : ApplicationService, IOrderItemAppService
    {
        private readonly IRepository<OrderItem, Guid> _orderItemRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Order, Guid> _OrderRepository;
        public OrderItemAppService(IRepository<OrderItem, Guid> orderItemRepository, IRepository<Product, Guid> productRepository, IRepository<Order, Guid> OrderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _OrderRepository = OrderRepository;
        }

        public async Task<OrderItemDto> CreateAsync(OrderItemDto input)
        {
            var orderItem = ObjectMapper.Map<OrderItem>(input);
            orderItem.Product = await _productRepository.GetAsync(input.ProductId);
            orderItem.Order = await _OrderRepository.GetAsync(input.OrderId);
            await _orderItemRepository.InsertAsync(orderItem);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<OrderItemDto>(orderItem);
        }

        public async Task Delete(Guid id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }

        public async Task<List<OrderItemDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var orderItems = await _orderItemRepository.GetAllIncluding(m => m.Product, o => o.Order).ToListAsync();
            return ObjectMapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetAsync(Guid id)
        {
            var orderItem = await _orderItemRepository.GetAllIncluding(m => m.Product, o => o.Order).FirstOrDefaultAsync(x => x.Id == id);
            if (orderItem == null)
                throw new UserFriendlyException("OrderItem not found!");
            return ObjectMapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<List<OrderItemDto>> GetByOrderId(Guid id)
        {
            var orderItems = await _orderItemRepository.GetAllIncluding(m => m.Product, o => o.Order).Where(e => e.Order.Id == id).Select(e => new OrderItemDto()
            {
                ProductId = e.Product.Id,
                Quantity = e.Quantity,
                Amount = e.Amount,
                OrderId = e.Order.Id,
                Name = e.Product.Name,

            }).ToListAsync();
            return ObjectMapper.Map<List<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> UpdateAsync(Guid id, OrderItemDto input)
        {
            var orderItem = _orderItemRepository.Get(input.Id);
            var updated = await _orderItemRepository.UpdateAsync(ObjectMapper.Map(input, orderItem));
            return ObjectMapper.Map<OrderItemDto>(updated);
        }
    }
}
