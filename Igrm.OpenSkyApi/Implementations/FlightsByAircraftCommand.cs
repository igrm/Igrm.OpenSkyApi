using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using Igrm.OpenSkyApi.Validation;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class FlightsByAircraftCommand : CommandBase<FlightsByAircraftRequestModel, FlightsByAircraftResponseModel, FlightsByAircraftRequestModelValidator>
    {
        public FlightsByAircraftCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, FlightsByAircraftRequestModel requestModel) : base(httpClient, authHeader, requestModel, OpenSkyApiConstants.SPECIFIED_AIRCRAFT_FLIGHTS_IN_INTERVAL, new FlightsByAircraftRequestModelValidator())
        {
        }
    }
}
