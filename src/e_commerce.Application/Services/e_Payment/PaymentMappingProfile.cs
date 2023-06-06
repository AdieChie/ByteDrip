using AutoMapper;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Payment
{
   public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment, PaymentDto>()
             .ForMember(e => e.OrderId, m => m.MapFrom(e => e.Order.Id));
            //mapping reflist

            CreateMap<PaymentDto, Payment>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
