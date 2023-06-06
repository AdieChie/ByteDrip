using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace e_commerce.Controllers
{
    public abstract class e_commerceControllerBase: AbpController
    {
        protected e_commerceControllerBase()
        {
            LocalizationSourceName = e_commerceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
