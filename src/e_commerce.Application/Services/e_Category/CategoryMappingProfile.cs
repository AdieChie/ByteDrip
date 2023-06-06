using AutoMapper;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
   public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap< CategoryDto, Category>();
        }
    }
}
