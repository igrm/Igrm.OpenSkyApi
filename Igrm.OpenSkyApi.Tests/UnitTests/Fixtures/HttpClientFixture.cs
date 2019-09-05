using System.Net.Http;

namespace Igrm.OpenSkyApi.Tests.UnitTests.Fixtures
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
