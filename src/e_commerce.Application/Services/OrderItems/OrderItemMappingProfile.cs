using AutoMapper;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.OrderItems
{
   public class OrderItemMappingProfile : Profile
    {
        public OrderItemMappingProfile()
        {
            CreateMap<OrderItem, OrderItemDto>()
               .ForMember(e => e.ProductId, m => m.MapFrom(e => e.Product.Id))
               .ForMember(e => e.OrderId, m => m.MapFrom(e => e.Order.Id));
           

            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
