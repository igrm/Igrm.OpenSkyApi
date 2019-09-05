using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Exceptions;
using Igrm.OpenSkyApi.Interfaces;
using Igrm.OpenSkyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Igrm.OpenSkyApi.Implementations
{
    public abstract class CommandBase<T, U> : ICommandWithResult<U>
    {
        protected String BaseUri { get { return $"{OpenSkyApiConstants.PROTOCOL}{OpenSkyApiConstants.HOST}{OpenSkyApiConstants.API_ROOT}"; } }

        public U Result { get; set; }

        private readonly HttpClient _httpClient;
        private readonly BasicAuthenticationHeader _authHeader;
        private readonly dynamic _requestModel;
        private readonly string _endPoint;

        public CommandBase(HttpClient httpClient, BasicAuthenticationHeader authHeader, T requestModel, string endPoint)
        {
            _httpClient = httpClient;
            _authHeader = authHeader;
            _requestModel = requestModel;
            _endPoint = endPoint;
        }

        protected U ProcessRequest(HttpRequestMessage httpRequestMessage)
        {
            var httpResponseMessageTask = _httpClient.SendAsync(httpRequestMessage);
            httpResponseMessageTask.Wait();
            if (httpResponseMessageTask.Result.IsSuccessStatusCode)
            {
                var stringTask = httpResponseMessageTask.Result.Content.ReadAsStringAsync();
                stringTask.Wait();
                return JsonConvert.DeserializeObject<U>(stringTask.Result);
            }
            else
            {
                throw new RequestFailedException($"{(int)httpResponseMessageTask.Result.StatusCode} {httpResponseMessageTask.Result.ReasonPhrase}");
            }
        }

        public void Execute()
        {
            UriBuilder builder = new UriBuilder($"{BaseUri}{_endPoint}");
            var parameterList = (List<KeyValuePair<string, string>>)_requestModel;
            builder.Query = String.Join("&", parameterList.Select(x => $"{x.Key}={x.Value}"));

            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, builder.Uri))
            {
                if (_authHeader != null)
                    httpRequestMessage.Headers.Authorization = _authHeader.GetAuthenticationHeaderValue();
                Result = ProcessRequest(httpRequestMessage);
            }
        }
    }
}
