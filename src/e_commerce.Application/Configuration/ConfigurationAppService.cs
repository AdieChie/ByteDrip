using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using e_commerce.Configuration.Dto;

namespace e_commerce.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : e_commerceAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
