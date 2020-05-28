using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Tests.IntegrationTests.Fixtures;
using Igrm.OpenSkyApi.Helpers;
using Xunit;
using System;
using Igrm.OpenSkyApi.Exceptions;
using System.Linq;
using Igrm.OpenSkyApi.Builders;

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
                var builder = new AllStateVectorsRequestBuilder();
                //ACT
                var response = client.GetAllStateVectors(builder.WithBoundingBox(45.8389m, 5.9962m, 47.8229m, 10.5226m).Build());
                //ASSERT
                Assert.True(response.StateVectors.Count > 0);
            }

            [Fact]
            public void CallGetArrivalsByAirport()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var builder = new ArrivalsByAirportRequestBuilder();
                //ACT
                var response = client.GetArrivalsByAirport(builder.WithAirport("OMDB").WithIntervalBegin(DateTime.UtcNow.AddHours(-48).ToUnixTimestamp()).WithIntervalEnd(DateTime.UtcNow.ToUnixTimestamp()).Build());
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetDeparturesByAirport()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var builder = new DeparturesByAirportRequestBuilder();
                //ACT
                var response = client.GetDeparturesByAirport(builder.WithAirport("OMDB").WithIntervalBegin(DateTime.UtcNow.AddHours(-48).ToUnixTimestamp()).WithIntervalEnd(DateTime.UtcNow.ToUnixTimestamp()).Build());
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetFlightsByAircraft()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var allStateVectorRequestBuilder = new AllStateVectorsRequestBuilder();
                var flightsByAircraftRequestBuilder = new FlightsByAircraftRequestBuilder();

                //ACT
                var flyingAircraftIcao24 = client.GetAllStateVectors(allStateVectorRequestBuilder.WithBoundingBox(45m, 5m, 47m, 10m).Build()).StateVectors.First().Icao24;
                var response = client.GetFlightsByAircraft(flightsByAircraftRequestBuilder.WithIcao24(flyingAircraftIcao24).WithIntervalBegin(DateTime.UtcNow.AddHours(-480).ToUnixTimestamp()).WithIntervalEnd(DateTime.UtcNow.ToUnixTimestamp()).Build());
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetFlightsInTimeInterval()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var builder = new FlightsInTimeIntervalRequestBuilder();
                //ACT
                var response = client.GetFlightsInTimeInterval(builder.WithIntervalBegin(1565746000).WithIntervalEnd(1565751701).Build());
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetOwnStateVectors()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient, "abc","abc");
                var builder = new OwnStateVectorsRequestBuilder();
                //ACT
                Exception ex = Assert.Throws<AggregateException>(() => client.GetOwnStateVectors(builder.AppendSerial(1).AppendIcao24("896471").Build()));
                //ASSERT
                Assert.Equal("401", ex.InnerException.Message.Trim());
            }

            [Fact]
            public void CallGetTrackByAircraft()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var trackByAircraftRequestBuilder = new TrackByAircraftRequestBuilder();
                var allStateVectorRequestBuilder = new AllStateVectorsRequestBuilder();
                //ACT
                var flyingAircraftIcao24 = client.GetAllStateVectors(allStateVectorRequestBuilder.WithBoundingBox(45m, 5m, 47m, 10m).Build()).StateVectors.Last().Icao24;
                var response = client.GetTrackByAircraft(trackByAircraftRequestBuilder.WithIcao24(flyingAircraftIcao24).WithTime(0).Build());
                //ASSERT
                Assert.True(response.Path.Count > 0);
            }
        }
    }
}
