using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using Igrm.OpenSkyApi.Validation;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class AllStateVectorsCommand : CommandBase<AllStateVectorsRequestModel, AllStateVectorsResponseModel, AllStateVectorsRequestModelValidator>
    {
        public AllStateVectorsCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, AllStateVectorsRequestModel requestModel):base(httpClient, authHeader, requestModel, OpenSkyApiConstants.AVAILABLE_STATES)
        {
        }
   }
}
