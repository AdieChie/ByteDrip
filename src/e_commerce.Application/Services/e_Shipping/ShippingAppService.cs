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

namespace e_commerce.Services.e_Shipping
{
    [AbpAuthorize]
    public class ShippingAppService : ApplicationService, IShippingAppService
    {
        private readonly IRepository<Shipping, Guid> _shippingRepository;
        private readonly IRepository<Order, Guid> _orderRepository;
        public ShippingAppService(IRepository<Shipping, Guid> shippingRepository , IRepository<Order, Guid> orderRepository)
        {
            _shippingRepository = shippingRepository;
            _orderRepository = orderRepository;
        }
        public async Task<ShippingDto> CreateAsync(ShippingDto input)
        {
            var shipping = ObjectMapper.Map<Shipping>(input);
            shipping.Order = await _orderRepository.GetAsync(input.OrderId);
            await _shippingRepository.InsertAsync(shipping);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<ShippingDto>(shipping);
        }

            public async Task Delete(Guid id)
        {
            await _shippingRepository.DeleteAsync(id);
        }

        public async Task<List<ShippingDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var shipping = await _shippingRepository.GetAllIncluding(m => m.Order).ToListAsync();
            return ObjectMapper.Map<List<ShippingDto>>(shipping);
        }

        public async Task<ShippingDto> GetAsync(Guid id)
        {
            var shipping = await _shippingRepository.GetAllIncluding(m => m.Order).FirstOrDefaultAsync(x => x.Id == id);
            if (shipping == null)
                throw new UserFriendlyException("OrderItem not found!");
            return ObjectMapper.Map<ShippingDto>(shipping);
        }

        public async Task<ShippingDto> UpdateAsync(Guid id, ShippingDto input)
        {
            var shipping = _shippingRepository.Get(input.Id);
            var updated = await _shippingRepository.UpdateAsync(ObjectMapper.Map(input, shipping));
            return ObjectMapper.Map<ShippingDto>(updated);
        }
    }
}
