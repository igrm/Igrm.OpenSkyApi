using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Exceptions;
using Igrm.OpenSkyApi.Interfaces;
using Igrm.OpenSkyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Igrm.OpenSkyApi.Implementations
{
    public abstract class CommandBase<T, U, V> : ICommandWithResult<U> where V : AbstractValidator<T>, new()
                                                                       where T : IRequestModel
    {
        protected String BaseUri { get { return $"{OpenSkyApiConstants.PROTOCOL}{OpenSkyApiConstants.HOST}{OpenSkyApiConstants.API_ROOT}"; } }

        public U Result { get; set; }

        private readonly HttpClient _httpClient;
        private readonly BasicAuthenticationHeader _authHeader;
        private readonly dynamic _requestModel;
        private readonly string _endPoint;
        private readonly V _validator;

        protected CommandBase(HttpClient httpClient, BasicAuthenticationHeader authHeader, T requestModel, string endPoint)
        {
            _httpClient = httpClient;
            _authHeader = authHeader;
            _requestModel = requestModel;
            _endPoint = endPoint;
            _validator = new V();
        }

        protected async Task<U> ProcessRequestAsync(HttpRequestMessage httpRequestMessage)
        {
            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new RequestFailedException($"{(int)httpResponseMessage.StatusCode} {httpResponseMessage.ReasonPhrase}");
            }
            var stringOutput = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<U>(stringOutput);
        }

        public async Task ExecuteAsync()
        {
            ValidationResult validationResult = _validator.Validate(_requestModel);

            if (!validationResult.IsValid)
            {
                throw new ModelValidationException(validationResult.Errors);
            }

            UriBuilder builder = new UriBuilder($"{BaseUri}{_endPoint}");
            var parameterList = (List<KeyValuePair<string, string>>)_requestModel;
            builder.Query = String.Join("&", parameterList.Select(x => $"{x.Key}={x.Value}"));

            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, builder.Uri))
            {
                if (_authHeader != null)
                    httpRequestMessage.Headers.Authorization = _authHeader.GetAuthenticationHeaderValue();
                Result = await ProcessRequestAsync(httpRequestMessage);
            }
        }
    }
}
