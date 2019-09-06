using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Igrm.OpenSkyApi.Models.Response
{
    public class Waypoint
    {
        ///<summary>
        ///Time which the given waypoint is associated with in seconds since epoch (Unix time).
        ///</summary>
        public long Time { get; set; }
        ///<summary>
        ///WGS-84 latitude in decimal degrees. Can be null.
        ///</summary>
        public decimal Latitude { get; set; }
        ///<summary>
        ///WGS-84 longitude in decimal degrees. Can be null.
        ///</summary>
        public decimal Longitude { get; set; }
        ///<summary>
        ///Barometric altitude in meters. Can be null.
        ///</summary>
        public decimal BaroAltitude { get; set; }
        ///<summary>
        ///True track in decimal degrees clockwise from north (north=0°). Can be null.
        ///</summary>
        public decimal TrueTrack { get; set; }
        ///<summary>
        ///Boolean value which indicates if the position was retrieved from a surface position report.
        ///</summary>
        public bool OnGround { get; set; }

        public static explicit operator Waypoint(dynamic[] array)
        {
            Waypoint waypoint = new Waypoint();
            int position = 0;

            Type waypointType = typeof(Waypoint);

            foreach (var item in array)
            {
                PropertyInfo pi = waypointType.GetProperties()[position];
                if (item != null)
                {
                    if (pi.PropertyType.Name == "Decimal")
                        pi.SetValue(waypoint, Convert.ToDecimal(item));
                    else
                        pi.SetValue(waypoint, item);
                }
                position++;
            }

            return waypoint;
        }
    }

    public class TrackByAircraftResponseModel
    {
        public TrackByAircraftResponseModel()
        {
        }
        ///<summary>
        ///Unique ICAO 24-bit address of the transponder in lower case hex string representation.
        ///</summary>
        public string Icao24 { get; set; }
        ///<summary>
        ///Time of the first waypoint in seconds since epoch (Unix time).
        ///</summary>
        public long Starttime { get; set; }
        ///<summary>
        ///Time of the last waypoint in seconds since epoch (Unix time).
        ///</summary>
        public long Endtime { get; set; }
        ///<summary>
        ///Callsign (8 characters) that holds for the whole track. Can be null.
        ///</summary>
        public string Calllsign { get; set; }
        ///<summary>
        ///Waypoints of the trajectory (description below).
        ///</summary>
        public List<Waypoint> Path => RawPath.Select(x=>(Waypoint)x).ToList();

        [JsonProperty("path")]
        public dynamic[][] RawPath { get; set; }
    }
}
