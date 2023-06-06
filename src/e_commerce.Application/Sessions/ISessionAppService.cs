using System.Threading.Tasks;
using Abp.Application.Services;
using e_commerce.Sessions.Dto;

namespace e_commerce.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
