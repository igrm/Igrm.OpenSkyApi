using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class FlightsInTimeIntervalRequestModel
    {
        /// <summary>
        /// Start of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public int Begin { get; set; }

        /// <summary>
        /// End of time interval to retrieve flights for as Unix time(seconds since epoch)
        /// </summary>
        public int End { get; set; }

        public static explicit operator List<KeyValuePair<string, string>>(FlightsInTimeIntervalRequestModel requestModel)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("begin", requestModel.Begin.ToString()));
            pairs.Add(new KeyValuePair<string, string>("end", requestModel.End.ToString()));
            return pairs;
        }
    }
}
