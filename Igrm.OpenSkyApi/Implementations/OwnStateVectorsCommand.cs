using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using Igrm.OpenSkyApi.Validation;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class OwnStateVectorsCommand : CommandBase<OwnStateVectorsRequestModel, OwnStateVectorsResponseModel, OwnStateVectorsRequestModelValidator>
    {
        public OwnStateVectorsCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, OwnStateVectorsRequestModel requestModel):base(httpClient, authHeader, requestModel, OpenSkyApiConstants.SPECIFIED_USER_STATES)
        {
        }
    }
}
