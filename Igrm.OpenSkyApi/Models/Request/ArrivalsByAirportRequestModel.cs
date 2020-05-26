using Igrm.OpenSkyApi.Interfaces;
using System;
using System.Collections.Generic;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class ArrivalsByAirportRequestModel : RequestModelBase
    {
        public ArrivalsByAirportRequestModel()
        {
            Airport = String.Empty;
        }
        /// <summary>
        /// ICAO identier for the airport
        /// </summary>
        public string Airport { get; set; }

        /// <summary>
        /// Start of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public long Begin { get; set; }

        /// <summary>
        /// End of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public long End { get; set; }

        public static explicit operator List<KeyValuePair<string, string>>(ArrivalsByAirportRequestModel requestModel)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("airport", requestModel.Airport));
            pairs.Add(new KeyValuePair<string, string>("begin", requestModel.Begin.ToString()));
            pairs.Add(new KeyValuePair<string, string>("end", requestModel.End.ToString()));
            return pairs;
        }
    }
}
