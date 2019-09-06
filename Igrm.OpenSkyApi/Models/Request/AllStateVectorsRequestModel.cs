using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class BoundingBox
    {
        /// <summary>
        /// lower bound for the latitude in decimal degrees
        /// </summary>
        public decimal Lamin { get; set; }

        /// <summary>
        /// lower bound for the longitude in decimal degrees
        /// </summary>        
        public decimal Lomin { get; set; }

        /// <summary>
        /// upper bound for the latitude in decimal degrees
        /// </summary>
        public decimal Lamax { get; set; }

        /// <summary>
        /// upper bound for the longitude in decimal degrees
        /// </summary>
        public decimal Lomax { get; set; }
    }

    public class AllStateVectorsRequestModel
    {
        public AllStateVectorsRequestModel()
        {
            Icao24 = new List<string>();
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
        /// Certain area defined by a bounding box of WGS84 coordinates
        /// </summary>
        public BoundingBox BoundingBox { get; set; }

        public static explicit operator List<KeyValuePair<string, string>>(AllStateVectorsRequestModel vectorsRequestModel)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();

            if (vectorsRequestModel.Time.HasValue)
            {
                pairs.Add(new KeyValuePair<string, string>("time", vectorsRequestModel.Time.Value.ToString()));
            }

            foreach(string icao24 in vectorsRequestModel.Icao24)
            {
                pairs.Add(new KeyValuePair<string, string>("icao24", icao24));
            }

            if(vectorsRequestModel.BoundingBox!=null)
            {
                pairs.Add(new KeyValuePair<string, string>("lamin", vectorsRequestModel.BoundingBox.Lamin.ToString("######.############", CultureInfo.InvariantCulture)));
                pairs.Add(new KeyValuePair<string, string>("lomin", vectorsRequestModel.BoundingBox.Lomin.ToString("######.############", CultureInfo.InvariantCulture)));
                pairs.Add(new KeyValuePair<string, string>("lamax", vectorsRequestModel.BoundingBox.Lamax.ToString("######.############", CultureInfo.InvariantCulture)));
                pairs.Add(new KeyValuePair<string, string>("lomax", vectorsRequestModel.BoundingBox.Lomax.ToString("######.############", CultureInfo.InvariantCulture)));
            }

            return pairs;
        }

    }
}
