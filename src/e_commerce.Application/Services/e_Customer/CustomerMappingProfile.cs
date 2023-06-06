using AutoMapper;
using e_commerce.Authorization.Users;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<CustomerDto, Customer>();
        }
    }
}
