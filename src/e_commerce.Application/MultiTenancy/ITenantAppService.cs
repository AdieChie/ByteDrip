using Abp.Application.Services;
using e_commerce.MultiTenancy.Dto;

namespace e_commerce.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

