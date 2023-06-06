using AutoMapper;
using e_commerce.Domain;
using e_commerce.Dtos;
using e_commerce.Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Order
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, ResponeDto>()
                .ForMember(e => e.CustomerId, m => m.MapFrom(e => e.Customer !=null? e.Customer.Id:(Guid?)null))
                .ForMember(e => e.orderCreationDate, m => m.MapFrom(e => e.CreationTime.Date.ToString().Substring(0,10).Replace(" ","")));
     
            CreateMap< UpdateDto, Order>();

            CreateMap<Order, OrderDto>()
                 .ForMember(e => e.CustomerId, m => m.MapFrom(e => e.Customer.Id));
              


            CreateMap<OrderDto, Order>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(e => e.Product, opt => opt.MapFrom(a => Util.GetEntity<Product>(a.ProductId)));
        }
    }
}
