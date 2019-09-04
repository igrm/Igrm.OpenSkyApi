using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Exceptions;
using Igrm.OpenSkyApi.Interfaces;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenSkyApi.Implementations
{
    public class AllStateVectorsCommand : CommandBase, ICommandWithResult<AllStateVectorsResponseModel>
    {
        private readonly BasicAuthenticationHeader _authHeader;
        private readonly AllStateVectorsRequestModel _requestModel;

        public AllStateVectorsCommand(HttpClient httpClient, BasicAuthenticationHeader authHeader, AllStateVectorsRequestModel requestModel)
        {
            _httpClient = httpClient;
            _requestModel = requestModel;
            _authHeader = authHeader;
        }

        public AllStateVectorsResponseModel Result { get; set; }

        public override void Execute()
        {
            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{BaseUri}{OpenSkyApiConstants.AVAILABLE_STATES}"))
            {
                if (_authHeader != null)
                    httpRequestMessage.Headers.Authorization = _authHeader.GetAuthenticationHeaderValue();
                httpRequestMessage.Content = new FormUrlEncodedContent((List<KeyValuePair<string, string>>)_requestModel);
                Result = ProcessRequest<AllStateVectorsResponseModel>(httpRequestMessage);
            }
        }
    }
}
