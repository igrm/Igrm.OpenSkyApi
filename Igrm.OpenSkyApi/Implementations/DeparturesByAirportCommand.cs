using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class DeparturesByAirportCommand : CommandBase<DeparturesByAirportRequestModel, DeparturesByAirportResponseModel>
    {
        public DeparturesByAirportCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, DeparturesByAirportRequestModel requestModel):base(httpClient, authHeader, requestModel, OpenSkyApiConstants.AIRPORT_DEPARTURES)
        {

        }
    }
}
