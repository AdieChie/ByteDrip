using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Payment
{
    public interface IPaymentAppService: IApplicationService
    {
        Task<PaymentDto> CreateAsync(PaymentDto input);
        Task<PaymentDto> UpdateAsync(Guid id, PaymentDto input);
        Task<List<PaymentDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<PaymentDto> GetAsync(Guid id);
        Task Delete(Guid id);
    }
}
