using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Igrm.OpenSkyApi.Tests.Fixtures
{
    public class HttpClientFixture
    {
        public HttpClient HttpClient { get; private set; }

        public void SetupHttpClient(HttpMessageHandler httpMessageHandler)
        {
            HttpClient = new HttpClient(httpMessageHandler);
        }
   }
}
