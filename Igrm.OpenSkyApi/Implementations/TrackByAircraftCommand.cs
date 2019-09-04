using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class TrackByAircraftCommand : CommandBase<TrackByAircraftRequestModel, TrackByAircraftResponseModel>
    {
        public TrackByAircraftCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, TrackByAircraftRequestModel requestModel):base(httpClient, authHeader, requestModel, OpenSkyApiConstants.SPECIFIED_AIRCRAFT_TRACK)
        {

        }
    }
}
