using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using e_commerce.Authorization;

namespace e_commerce
{
    [DependsOn(
        typeof(e_commerceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class e_commerceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<e_commerceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(e_commerceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
