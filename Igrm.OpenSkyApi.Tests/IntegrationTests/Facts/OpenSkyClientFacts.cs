using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Tests.IntegrationTests.Fixtures;
using Xunit;

namespace Igrm.OpenSkyApi.Tests.IntegrationTests.Facts
{
    public class OpenSkyClientFacts 
    {
        public class OpenSkyClientIntegration: IClassFixture<HttpClientFixture>
        {
            private readonly HttpClientFixture _httpClientFixture;

            public OpenSkyClientIntegration(HttpClientFixture httpClientFixture)
            {
                _httpClientFixture = httpClientFixture;
            }

            [Fact]
            public void CallGetAllStateVectors()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                //ACT
                var response = client.GetAllStateVectors(new AllStateVectorsRequestModel() { BoundingBox = new BoundingBox() { Lamin = 45.8389m, Lomin = 5.9962m, Lamax = 47.8229m, Lomax = 10.5226m } });
                //ASSERT
                Assert.True(response.StateVectors.Count > 0);
            }
        }
    }
}
