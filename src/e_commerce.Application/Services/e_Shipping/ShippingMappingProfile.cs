using AutoMapper;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Shipping
{
    public class ShippingMappingProfile :Profile
    {
        public ShippingMappingProfile()
        {
            CreateMap<Shipping, ShippingDto>()
              .ForMember(e => e.OrderId, m => m.MapFrom(e => e.Order.Id));


            CreateMap<ShippingDto, Shipping>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
