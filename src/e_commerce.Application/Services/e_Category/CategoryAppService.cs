using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using e_commerce.Domain;
using e_commerce.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce.Services
{
    [AbpAuthorize]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, Guid>, ICategoryAppService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

    public CategoryAppService(IRepository<Category, Guid> categoryRepository) : base(categoryRepository)
    {
            _categoryRepository = categoryRepository;

    }

        //public override Task<List<CategoryDto>> GetAll()
        //{
        //    return base.GetAllAsync();
        //}
    }
}
