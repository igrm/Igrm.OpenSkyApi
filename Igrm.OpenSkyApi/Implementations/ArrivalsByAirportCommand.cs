using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class ArrivalsByAirportCommand : CommandBase<ArrivalsByAirportRequestModel, ArrivalsByAirportResponseModel>
    {
        public ArrivalsByAirportCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, ArrivalsByAirportRequestModel requestModel): base(httpClient, authHeader, requestModel, OpenSkyApiConstants.AIRPORT_ARRIVALS)
        {

        }
    }
}
