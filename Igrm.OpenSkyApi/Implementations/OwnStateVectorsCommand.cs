using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class OwnStateVectorsCommand : CommandBase<OwnStateVectorsRequestModel, OwnStateVectorsResponseModel>
    {
        public OwnStateVectorsCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, OwnStateVectorsRequestModel requestModel):base(httpClient, authHeader, requestModel, OpenSkyApiConstants.SPECIFIED_USER_STATES)
        {
        }
    }
}
