using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class ArrivalsByAirportRequestModel
    {
        /// <summary>
        /// ICAO identier for the airport
        /// </summary>
        public string Airport { get; set; }

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
