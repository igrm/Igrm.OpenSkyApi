using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;

namespace Igrm.OpenSkyApi.Models
{
    public class BasicAuthenticationHeader
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public AuthenticationHeaderValue GetAuthenticationHeaderValue()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{Username}:{Password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}
