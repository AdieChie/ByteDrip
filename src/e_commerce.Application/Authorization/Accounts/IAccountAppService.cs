using System.Threading.Tasks;
using Abp.Application.Services;
using e_commerce.Authorization.Accounts.Dto;

namespace e_commerce.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
