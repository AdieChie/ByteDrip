using System.Threading.Tasks;
using e_commerce.Models.TokenAuth;
using e_commerce.Web.Controllers;
using Shouldly;
using Xunit;

namespace e_commerce.Web.Tests.Controllers
{
    public class HomeController_Tests: e_commerceWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}