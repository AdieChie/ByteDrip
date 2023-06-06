using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using e_commerce.EntityFrameworkCore;
using e_commerce.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace e_commerce.Web.Tests
{
    [DependsOn(
        typeof(e_commerceWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class e_commerceWebTestModule : AbpModule
    {
        public e_commerceWebTestModule(e_commerceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(e_commerceWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(e_commerceWebMvcModule).Assembly);
        }
    }
}