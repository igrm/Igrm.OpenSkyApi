using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Exceptions
{
    public class ParameterListException: Exception
    {
        public ParameterListException(string message) : base(message)
        {

        }
    }
}
