using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using TDD_CloudCustomers.API.Models.UserRelated;

namespace TDD_CloudCustomers.UnitTest.Helpers
{
    internal static class MockHttpHandler<T>
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
        {
            var mockReponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))

            };

            mockReponse.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockReponse);

            return handlerMock;
        }
        //internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<User> expectedResponse, string endpoint)
        //{
        //    var mockReponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
        //    };

        //    mockReponse.Content.Headers.ContentType =
        //        new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            
        //    var handlerMock = new Mock<HttpMessageHandler>();


        //    var httpRequestMessage = new HttpRequestMessage
        //    {
        //        RequestUri = new Uri(endpoint),
        //        Method = HttpMethod.Get
        //    };

        //    handlerMock.Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //        "SendAsync",
        //        httpRequestMessage,
        //        ItExpr.IsAny<CancellationToken>())
        //        .ReturnsAsync(mockReponse);

        //    return handlerMock;
        //}

        internal static Mock<HttpMessageHandler> SetupReturn404()
        {
            var mockReponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
            {
                Content = new StringContent("")

            };

            mockReponse.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockReponse);

            return handlerMock;
        }

    }
}
