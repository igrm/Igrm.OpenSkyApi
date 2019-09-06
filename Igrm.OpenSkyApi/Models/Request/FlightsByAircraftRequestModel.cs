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
        public long Begin { get; set; }

        /// <summary>
        /// End of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public long End { get; set; }

        public static explicit operator List<KeyValuePair<string, string>>(FlightsByAircraftRequestModel requestModel)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("begin", requestModel.Begin.ToString()));
            pairs.Add(new KeyValuePair<string, string>("end", requestModel.End.ToString()));
            pairs.Add(new KeyValuePair<string, string>("icao24", requestModel.Icao24));
            return pairs;
        }
    }
}
