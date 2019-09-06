using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class OwnStateVectorsRequestModel
    {
        public OwnStateVectorsRequestModel()
        {
            Icao24 = new List<string>();
            Serials = new List<long>();
        }
        /// <summary>
        /// The time in seconds since epoch (Unix time stamp to retrieve states for. Current time will be used if omitted.
        /// </summary>
        public long? Time { get; set; }

        /// <summary>
        /// One or more ICAO24 transponder addresses represented by a hex string (e.g. abc9f3). To filter multiple ICAO24 append the property once for each address. If omitted, the state vectors of all aircraft are returned.
        /// </summary>
        public List<string> Icao24 { get; set; }

        /// <summary>
        /// Retrieve only states of a subset of your receivers. You can pass this argument several time to filter state of more than one of your receivers. In this case, the API returns all states of aircraft that are visible to at least one of the given receivers.
        /// </summary>
        public List<long> Serials { get; set; }

        public static explicit operator List<KeyValuePair<string, string>>(OwnStateVectorsRequestModel vectorsRequestModel)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            if(vectorsRequestModel.Time.HasValue)
            {
                pairs.Add(new KeyValuePair<string, string>("time", vectorsRequestModel.Time.Value.ToString()));
            }
            foreach (string icao24 in vectorsRequestModel.Icao24)
            {
                pairs.Add(new KeyValuePair<string, string>("icao24", icao24));
            }

            foreach (int serials in vectorsRequestModel.Serials)
            {
                pairs.Add(new KeyValuePair<string, string>("serials", serials.ToString()));
            }
            return pairs;
        }
    }
}
