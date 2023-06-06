using AutoMapper;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services.e_Product
{
   public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(e => e.CategoryId, m => m.MapFrom(e => e.Category.Id));
        
            CreateMap<ProductDto, Product>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
