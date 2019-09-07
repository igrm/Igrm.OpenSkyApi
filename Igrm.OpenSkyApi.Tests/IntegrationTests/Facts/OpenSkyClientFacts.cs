using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Tests.IntegrationTests.Fixtures;
using Igrm.OpenSkyApi.Helpers;
using Xunit;
using System;
using Igrm.OpenSkyApi.Exceptions;
using System.Linq;

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
                var response = client.GetArrivalsByAirport(new ArrivalsByAirportRequestModel() { Airport = "OMDB", Begin = DateTime.UtcNow.AddHours(-48).ToUnixTimestamp(), End = DateTime.UtcNow.ToUnixTimestamp() });
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetDeparturesByAirport()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                //ACT
                var response = client.GetDeparturesByAirport(new DeparturesByAirportRequestModel() { Airport="OMDB", Begin = DateTime.UtcNow.AddHours(-48).ToUnixTimestamp(), End = DateTime.UtcNow.ToUnixTimestamp() });
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetFlightsByAircraft()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                //ACT
                var flyingAircraftIcao24 = client.GetAllStateVectors(new AllStateVectorsRequestModel() { BoundingBox = new BoundingBox() { Lamin = 45.8389m, Lomin = 5.9962m, Lamax = 47.8229m, Lomax = 10.5226m } }).StateVectors.First().Icao24;
                var response = client.GetFlightsByAircraft(new FlightsByAircraftRequestModel() { Icao24 = flyingAircraftIcao24, Begin = DateTime.UtcNow.AddHours(-48).ToUnixTimestamp(), End = DateTime.UtcNow.ToUnixTimestamp() });
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetFlightsInTimeInterval()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                //ACT
                var response = client.GetFlightsInTimeInterval(new FlightsInTimeIntervalRequestModel() { Begin = 1565746000 , End = 1565751701 });
                //ASSERT
                Assert.True(response.Count > 0);
            }

            [Fact]
            public void CallGetOwnStateVectors()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient, "abc","abc");
                //ACT
                Exception ex = Assert.Throws<RequestFailedException>(() => client.GetOwnStateVectors(new OwnStateVectorsRequestModel() { Serials = new System.Collections.Generic.List<long>() { 1 }, Icao24 = new System.Collections.Generic.List<string>() { "896471" } }));
                //ASSERT
                Assert.Equal("401", ex.Message.Trim());
            }

            [Fact]
            public void CallGetTrackByAircraft()
            {
                //ARRANGE
                var client = new OpenSkyClient(_httpClientFixture.HttpClient);
                //ACT
                var response = client.GetTrackByAircraft(new TrackByAircraftRequestModel() { Icao24 = "4b1805", Time = 1567676180 });
                //ASSERT
                Assert.True(response.Path.Count > 0);
            }
        }
    }
}
