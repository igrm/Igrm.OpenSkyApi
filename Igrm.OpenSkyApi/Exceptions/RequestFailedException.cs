using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Exceptions
{
    public class RequestFailedException: Exception
    {
        public RequestFailedException(String message):base(message)
        {

        }
    }
}
