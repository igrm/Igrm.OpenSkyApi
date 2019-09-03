using System;
using System.Collections.Generic;
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
        /// <summary>
        /// The time in seconds since epoch (Unix time stamp to retrieve states for. Current time will be used if omitted.
        /// </summary>
        public int? Time { get; set; }

        /// <summary>
        /// One or more ICAO24 transponder addresses represented by a hex string (e.g. abc9f3). To filter multiple ICAO24 append the property once for each address. If omitted, the state vectors of all aircraft are returned.
        /// </summary>
        public List<string> Icao24 { get; set; }

        /// <summary>
        /// Certain area defined by a bounding box of WGS84 coordinates
        /// </summary>
        public BoundingBox BoundingBox { get; set; }

    }
}
