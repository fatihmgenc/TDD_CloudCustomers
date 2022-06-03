using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_CloudCustomers.API.Models.Config;
using TDD_CloudCustomers.API.Models.UserRelated;
using TDD_CloudCustomers.API.Services.Implementation.UserServices;
using TDD_CloudCustomers.UnitTest.Fixtures;
using TDD_CloudCustomers.UnitTest.Helpers;
using Xunit;

namespace TDD_CloudCustomers.UnitTest.Systems.Services
{
    public class TestUserService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequests()
        {
            // arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "Https://example.com/users";
            var handlerMock = MockHttpHandler<User>
                .SetupBasicGetResourceList(expectedResponse);

            var conf = Options.Create(new UserApiOptions
            {
                EndPoint = endpoint
            });
            var httpClient = new HttpClient(handlerMock.Object);
            var userService = new UserService(httpClient, conf);

            // act
            await userService.GetAll();

            // Assert
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());

        }
        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnListOfUsers()
        {
            // arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "Https://example.com/users";
            var handlerMock = MockHttpHandler<User>
                .SetupBasicGetResourceList(expectedResponse);
            var conf = Options.Create(new UserApiOptions
            {
                EndPoint = endpoint
            });
            var httpClient = new HttpClient(handlerMock.Object);
            var userService = new UserService(httpClient, conf);

            // act
            var usersResult = await userService.GetAll();

            // Assert
            usersResult.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsExpectedSize()
        {
            // arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "Https://example.com/users";
            var handlerMock = MockHttpHandler<User>
                .SetupBasicGetResourceList(expectedResponse);

            var conf = Options.Create(new UserApiOptions
            {
                EndPoint = endpoint
            });
            var httpClient = new HttpClient(handlerMock.Object);
            var userService = new UserService(httpClient, conf);
            // act
            var usersResult = await userService.GetAll();

            // Assert
            usersResult.Count().Should().Be(UsersFixture.GetTestUsers().Count);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {

            // arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "Https://example.com/users";
            var handlerMock = MockHttpHandler<User>
                .SetupBasicGetResourceList(expectedResponse);

            var conf = Options.Create(new UserApiOptions
            {
                EndPoint = endpoint
            });
            var httpClient = new HttpClient(handlerMock.Object);
            var userService = new UserService(httpClient, conf);

            // act
            await userService.GetAll();

            // Assert
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == new Uri(endpoint)),
                ItExpr.IsAny<CancellationToken>());
        }


    }
}
