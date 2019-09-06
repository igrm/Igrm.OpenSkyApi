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

namespace Igrm.OpenSkyApi.Implementations
{
    public abstract class CommandBase<T, U, V>  : ICommandWithResult<U> where V : AbstractValidator<T>
    {
        protected String BaseUri { get { return $"{OpenSkyApiConstants.PROTOCOL}{OpenSkyApiConstants.HOST}{OpenSkyApiConstants.API_ROOT}"; } }

        public U Result { get; set; }

        private readonly HttpClient _httpClient;
        private readonly BasicAuthenticationHeader _authHeader;
        private readonly dynamic _requestModel;
        private readonly string _endPoint;
        private readonly V _validator;

        public CommandBase(HttpClient httpClient, BasicAuthenticationHeader authHeader, T requestModel, string endPoint, V validator)
        {
            _httpClient = httpClient;
            _authHeader = authHeader;
            _requestModel = requestModel;
            _endPoint = endPoint;
            _validator = validator;
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
            ValidationResult validationResult = _validator.Validate(_requestModel);

            if (validationResult.IsValid)
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
            else
            {
                throw new ModelValidationException(validationResult.Errors);
            }
        }
    }
}
