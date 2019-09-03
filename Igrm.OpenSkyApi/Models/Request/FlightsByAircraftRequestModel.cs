using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class FlightsByAircraftRequestModel
    {
        /// <summary>
        /// Unique ICAO 24-bit address of the transponder in hex string representation. All letters need to be lower case
        /// </summary>
        public String Icao24 { get; set; }

        /// <summary>
        /// Start of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public int Begin { get; set; }

        /// <summary>
        /// End of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public int End { get; set; }
    }
}
