using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Tests.IntegrationTests.Fixtures;
using Igrm.OpenSkyApi.Helpers;
using Xunit;
using System;

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

            [Fact]
            public void CallGetArrivalsByAirport()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                //ACT
                var response = client.GetArrivalsByAirport(new ArrivalsByAirportRequestModel() { Airport = "OMDB", Begin = DateTime.UtcNow.AddHours(-8).ToUnixTimestamp(), End = DateTime.UtcNow.ToUnixTimestamp() });
                //ASSERT
                Assert.True(response.Count > 0);
            }
        }
    }
}
