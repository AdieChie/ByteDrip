using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using e_commerce.Domain;
using e_commerce.Dtos;
using e_commerce.Services.notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Payment
{
    [AbpAuthorize]
    public class PaymentAppService : ApplicationService, IPaymentAppService
    {
        private readonly IRepository<Payment, Guid> _paymentRepository;
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<Shipping, Guid> _shippingRepository;
        public PaymentAppService(IRepository<Payment, Guid> paymentRepository , IRepository<Order, Guid> orderRepository, IRepository<Shipping, Guid> shippingRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _shippingRepository = shippingRepository;
        }
        public async Task<PaymentDto> CreateAsync(PaymentDto input)
        {
            var payment = ObjectMapper.Map<Payment>(input);
            payment.Order = await _orderRepository.GetAsync(input.OrderId);
            await _paymentRepository.InsertAsync(payment);
            CurrentUnitOfWork.SaveChanges();
            var cell = "+27790743775"; 
            Notification.SendMessage(cell, "Your order is being processed. It will be delivered in 2-3 working days. Thank you for shopping with us!");
            return ObjectMapper.Map<PaymentDto>(payment);
            var ship = _shippingRepository.GetAllIncluding(m => m.Order).FirstOrDefault(m => m.Order == payment.Order);
         
        }

        public async Task Delete(Guid id)
        {
            await _paymentRepository.DeleteAsync(id);
        }

        public async Task<List<PaymentDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var payment = await _paymentRepository.GetAllIncluding(m => m.Order).ToListAsync();
            return ObjectMapper.Map<List<PaymentDto>>(payment);
        }

        public async Task<PaymentDto> GetAsync(Guid id)
        {
            var payment = await _paymentRepository.GetAllIncluding(m => m.Order).FirstOrDefaultAsync(x => x.Id == id);
            if (payment == null)
                throw new UserFriendlyException("OrderItem not found!");
            return ObjectMapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> UpdateAsync(Guid id, PaymentDto input)
        {
            var payment = _paymentRepository.Get(input.Id);
            var updated = await _paymentRepository.UpdateAsync(ObjectMapper.Map(input, payment));
            return ObjectMapper.Map<PaymentDto>(updated);
        }
    }
}
