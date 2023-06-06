using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using e_commerce.MultiTenancy;

namespace e_commerce.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
