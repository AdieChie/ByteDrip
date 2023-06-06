using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.UI;
using e_commerce.Authorization.Users;
using e_commerce.Domain;
using e_commerce.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
  
   public class CustomerAppService : ApplicationService , ICustomerAppService
    {
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly UserManager _userManager;

        public CustomerAppService(IRepository<Customer, Guid> customerRepository, UserManager userManager)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            var customer = ObjectMapper.Map<Customer>(input);
            customer.User = user;
            await _customerRepository.InsertAsync(customer);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<CustomerDto>(customer);
        }
        public async Task Delete(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
        }
        public async Task<List<CustomerDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            var customer = await _customerRepository.GetAllIncluding(m => m.User).ToListAsync();
            return ObjectMapper.Map<List<CustomerDto>>(customer);
        }
        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAllIncluding(m => m.User).FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
                throw new UserFriendlyException("Customer not found !");
            return ObjectMapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetByUserId(long id)
        {
            var customer = await _customerRepository.GetAllIncluding(m => m.User).FirstOrDefaultAsync(x => x.User.Id == id);
            if (customer == null)
                throw new UserFriendlyException("Customer not found !");
            return ObjectMapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto input)
        {
            var customer = _customerRepository.Get(input.Id);
            var up = ObjectMapper.Map(input, customer);
            var updated = await _customerRepository.UpdateAsync(up);
            return ObjectMapper.Map<CustomerDto>(updated);
        }


        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
