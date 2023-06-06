using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using e_commerce.Configuration;
using e_commerce.Web;

namespace e_commerce.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class e_commerceDbContextFactory : IDesignTimeDbContextFactory<e_commerceDbContext>
    {
        public e_commerceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<e_commerceDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            e_commerceDbContextConfigurer.Configure(builder, configuration.GetConnectionString(e_commerceConsts.ConnectionStringName));

            return new e_commerceDbContext(builder.Options);
        }
    }
}
