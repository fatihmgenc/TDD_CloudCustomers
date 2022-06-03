using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TDD_CloudCustomers.Controllers;
using Xunit;

namespace TDD_CloudCustomers.UnitTest.Systems.Controllers
{
    public class TestsUserController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // arrange 
            var sut = new UserController();
            // act 
            var result = (OkObjectResult)await sut.Get();
            // assetrt
            result.StatusCode.Should().Be(200);

        }
    }
}