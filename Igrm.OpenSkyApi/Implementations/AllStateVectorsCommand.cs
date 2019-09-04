using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System.Net.Http;

namespace Igrm.OpenSkyApi.Implementations
{
    public class AllStateVectorsCommand : CommandBase<AllStateVectorsRequestModel, AllStateVectorsResponseModel>
    {
        public AllStateVectorsCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, AllStateVectorsRequestModel requestModel):base(httpClient, authHeader, requestModel, OpenSkyApiConstants.AVAILABLE_STATES)
        {
        }
   }
}
