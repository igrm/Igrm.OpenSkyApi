using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Tests.Fixtures;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Igrm.OpenSkyApi.Tests.Facts
{
    public class OpenSkyClientFacts
    {
        public class GetAllStateVectorsMethod : IClassFixture<HttpClientFixture>
        {
            private readonly HttpClientFixture _httpClientFixture;

            public GetAllStateVectorsMethod(HttpClientFixture httpClientFixture)
            {
                _httpClientFixture = httpClientFixture;
            }

            [Fact]
            void WhenBoudingBoxProvided_ReturnsListOfStates()
            {
                //ARRANGE
                var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Loose);
                handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                                                      "SendAsync",
                                                      ItExpr.IsAny<HttpRequestMessage>(),
                                                      ItExpr.IsAny<CancellationToken>())
                            .ReturnsAsync(new HttpResponseMessage()
                                        {
                                            StatusCode = HttpStatusCode.OK,
                                            Content = new StringContent("[{'id':1,'value':'1'}]"),
                                        });
                _httpClientFixture.SetupHttpClient(handlerMock.Object);

                //ACT
                IOpenSkyClient client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var response = client.GetAllStateVectors(new AllStateVectorsRequestModel() { BoundingBox = new BoundingBox() { Lamin = 45.8389m, Lomin = 5.9962m, Lamax = 47.8229m, Lomax = 10.5226m } });

                //ASSERT
                Assert.True(response.StateVectors.Count>0);
            }
        }
    }
}
