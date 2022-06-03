using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDD_CloudCustomers.API.Models.UserRelated;
using TDD_CloudCustomers.API.Services.Abstract.UserServices;
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
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAll())
                .ReturnsAsync(new List<User>());
            var sut = new UserController(mockUserService.Object);

            // act 
            var result = (OkObjectResult)await sut.Get();
            // assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserService()
        {
            // arrange 
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAll())
                .ReturnsAsync(new List<User>());
            var sut = new UserController(mockUserService.Object);

            // act 
            var result = await sut.Get();


            // assert

            mockUserService.Verify(s => s.GetAll(), Times.Once());

        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            // arrange 
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetAll())
                .ReturnsAsync(new List<User>());
            var sut = new UserController(mockUserService.Object);

            // act 
            var result = await sut.Get();

            // assert

            result.Should().BeOfType<OkObjectResult>();
            var objecttResult = (OkObjectResult)result;
            objecttResult.Value.Should().BeOfType<List<User>>();
        }

        


    }
}