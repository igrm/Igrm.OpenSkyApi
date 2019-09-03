using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Response
{
    public class Waypoint
    {
        ///<summary>
        ///Time which the given waypoint is associated with in seconds since epoch (Unix time).
        ///</summary>
        public int Time { get; set; }
        ///<summary>
        ///WGS-84 latitude in decimal degrees. Can be null.
        ///</summary>
        public float Latitude { get; set; }
        ///<summary>
        ///WGS-84 longitude in decimal degrees. Can be null.
        ///</summary>
        public float Longitude { get; set; }
        ///<summary>
        ///Barometric altitude in meters. Can be null.
        ///</summary>
        public float BaroAltitude { get; set; }
        ///<summary>
        ///True track in decimal degrees clockwise from north (north=0°). Can be null.
        ///</summary>
        public float TrueTrack { get; set; }
        ///<summary>
        ///Boolean value which indicates if the position was retrieved from a surface position report.
        ///</summary>
        public bool OnGround { get; set; }

    }

    public class TrackByAircraftResponseModel
    {
        ///<summary>
        ///Unique ICAO 24-bit address of the transponder in lower case hex string representation.
        ///</summary>
        public string Icao24 { get; set; }
        ///<summary>
        ///Time of the first waypoint in seconds since epoch (Unix time).
        ///</summary>
        public int Starttime { get; set; }
        ///<summary>
        ///Time of the last waypoint in seconds since epoch (Unix time).
        ///</summary>
        public int Endtime { get; set; }
        ///<summary>
        ///Callsign (8 characters) that holds for the whole track. Can be null.
        ///</summary>
        public string Calllsign { get; set; }
        ///<summary>
        ///Waypoints of the trajectory (description below).
        ///</summary>
        public List<Waypoint> Path { get; set; }

    }
}
