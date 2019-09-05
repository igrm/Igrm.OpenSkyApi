﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Response
{
    public enum PositionSource
    {
        ADSB = 0,
        ASTERIX=1, 
        MLAT=2
    }

    public class StateVector
    {
        ///<summary>
        ///Unique ICAO 24-bit address of the transponder in hex string representation.
        ///</summary>
        public string Icao24 { get; set; }
        ///<summary>
        ///Callsign of the vehicle (8 chars). Can be null if no callsign has been received.
        ///</summary>
        public string Callsign { get; set; }
        ///<summary>
        ///Country name inferred from the ICAO 24-bit address.
        ///</summary>
        public string OriginCountry { get; set; }
        ///<summary>
        ///Unix timestamp (seconds) for the last position update. Can be null if no position report was received by OpenSky within the past 15s.
        ///</summary>
        public int TimePosition { get; set; }
        ///<summary>
        ///Unix timestamp (seconds) for the last update in general. This field is updated for any new, valid message received from the transponder.
        ///</summary>
        public int LastContact { get; set; }
        ///<summary>
        ///WGS-84 longitude in decimal degrees. Can be null.
        ///</summary>
        public decimal Longitude { get; set; }
        ///<summary>
        ///WGS-84 latitude in decimal degrees. Can be null.
        ///</summary>
        public decimal Latitude { get; set; }
        ///<summary>
        ///Barometric altitude in meters. Can be null.
        ///</summary>
        public decimal BaroAltitude { get; set; }
        ///<summary>
        ///Boolean value which indicates if the position was retrieved from a surface position report.
        ///</summary>
        public bool OnGround { get; set; }
        ///<summary>
        ///Velocity over ground in m/s. Can be null.
        ///</summary>
        public decimal Velocity { get; set; }
        ///<summary>
        ///True track in decimal degrees clockwise from north (north=0°). Can be null.
        ///</summary>
        public decimal TrueTrack { get; set; }
        ///<summary>
        ///Vertical rate in m/s. A positive value indicates that the airplane is climbing, a negative value indicates that it descends. Can be null.
        ///</summary>
        public decimal VerticalRate { get; set; }
        ///<summary>
        ///IDs of the receivers which contributed to this state vector. Is null if no filtering for sensor was used in the request.
        ///</summary>
        public int[] Sensors { get; set; }
        ///<summary>
        ///Geometric altitude in meters. Can be null.
        ///</summary>
        public decimal GeoAltitude { get; set; }
        ///<summary>
        ///The transponder code aka Squawk. Can be null.
        ///</summary>
        public string Squawk { get; set; }
        ///<summary>
        ///Whether flight status indicates special purpose indicator.
        ///</summary>
        public bool Spi { get; set; }
        ///<summary>
        ///Origin of this state’s position: 0 = ADS-B, 1 = ASTERIX, 2 = MLAT
        ///</summary>
        public PositionSource PositionSource { get; set; }

    }

    public class AllStateVectorsResponseModel
    {
        /// <summary>
        /// The time which the state vectors in this response are associated with. All vectors represent the state of a vehicle with the interval [time−1,time].
        /// </summary>
        public int Time { get; set; }
 
        /// <summary>
        /// The state vectors.
        /// </summary>
        public List<StateVector> StateVectors { get; set; }
    }
}