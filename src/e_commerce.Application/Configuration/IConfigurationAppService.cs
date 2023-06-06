using System.Threading.Tasks;
using e_commerce.Configuration.Dto;

namespace e_commerce.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
