using Igrm.OpenSkyApi.Constants;
using Igrm.OpenSkyApi.Exceptions;
using Igrm.OpenSkyApi.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Igrm.OpenSkyApi.Implementations
{
    public abstract class CommandBase : ICommand
    {
        public abstract void Execute();

        protected String BaseUri { get { return $"{OpenSkyApiConstants.PROTOCOL}{OpenSkyApiConstants.HOST}"; } }

        protected HttpClient _httpClient;

        protected T ProcessRequest<T>(HttpRequestMessage httpRequestMessage)
        {
            var httpResponseMessageTask = _httpClient.SendAsync(httpRequestMessage);
            httpResponseMessageTask.Wait();
            if (httpResponseMessageTask.Result.IsSuccessStatusCode)
            {
                var stringTask = httpResponseMessageTask.Result.Content.ReadAsStringAsync();
                stringTask.Wait();
                return JsonConvert.DeserializeObject<T>(stringTask.Result);
            }
            else
            {
                throw new RequestFailedException($"{httpResponseMessageTask.Result.StatusCode} {httpResponseMessageTask.Result.ReasonPhrase}");
            }
        }
    }
}
