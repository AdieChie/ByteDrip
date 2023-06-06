using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using e_commerce.Configuration;

namespace e_commerce.Web.Host.Startup
{
    [DependsOn(
       typeof(e_commerceWebCoreModule))]
    public class e_commerceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public e_commerceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(e_commerceWebHostModule).GetAssembly());
        }
    }
}
