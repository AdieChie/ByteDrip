using Abp.Application.Services;
using Abp.Application.Services.Dto;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
   public interface ICustomerAppService : IApplicationService
    {
        Task<CustomerDto> CreateAsync(CustomerDto input);
        Task<CustomerDto> UpdateAsync(CustomerDto input);
        Task<List<CustomerDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<CustomerDto> GetAsync(Guid id);
        Task<CustomerDto> GetByUserId(long id);
        Task Delete(Guid id);
    }
}
