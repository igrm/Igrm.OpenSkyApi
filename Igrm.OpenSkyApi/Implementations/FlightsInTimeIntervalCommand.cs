using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using Igrm.OpenSkyApi.Validation;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class FlightsInTimeIntervalCommand : CommandBase<FlightsInTimeIntervalRequestModel, FlightsInTimeIntervalResponseModel, FlightsInTimeIntervalRequestModelValidator>
    {
        public FlightsInTimeIntervalCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, FlightsInTimeIntervalRequestModel requestModel) : base(httpClient, authHeader, requestModel, OpenSkyApiConstants.ALL_FLIGHTS_IN_INTERVAL)
        {

        }
    }
}
