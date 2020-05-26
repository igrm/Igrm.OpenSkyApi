using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Igrm.OpenSkyApi.Models.Response
{
    public enum PositionSource
    {
        ADSB = 0,
        ASTERIX = 1,
        MLAT = 2
    }

    public class StateVector
    {
        public StateVector()
        {
            Icao24 = String.Empty;
            CallSign = String.Empty;
            OriginCountry = String.Empty;
            Squawk = String.Empty;

        }
        ///<summary>
        ///Unique ICAO 24-bit address of the transponder in hex string representation.
        ///</summary>
        public string Icao24 { get; set; }
        ///<summary>
        ///Callsign of the vehicle (8 chars). Can be null if no callsign has been received.
        ///</summary>
        public string CallSign { get; set; }
        ///<summary>
        ///Country name inferred from the ICAO 24-bit address.
        ///</summary>
        public string OriginCountry { get; set; }
        ///<summary>
        ///Unix timestamp (seconds) for the last position update. Can be null if no position report was received by OpenSky within the past 15s.
        ///</summary>
        public long TimePosition { get; set; }
        ///<summary>
        ///Unix timestamp (seconds) for the last update in general. This field is updated for any new, valid message received from the transponder.
        ///</summary>
        public long LastContact { get; set; }
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
        public long[]? Sensors { get; set; }
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
        public long PositionSource { get; set; }

        public static explicit operator StateVector(dynamic[] array)
        {
            StateVector stateVector = new StateVector();
            int position = 0;

            Type stateVectorType = typeof(StateVector);

            foreach (var item in array)
            {
                PropertyInfo pi = stateVectorType.GetProperties()[position];
                if (item != null)
                {
                    if (pi.PropertyType.Name == "Decimal")
                        pi.SetValue(stateVector, Convert.ToDecimal(item));
                    else
                        pi.SetValue(stateVector, item);
                }
                position++;
            }

            return stateVector;
        }

    }

    public class AllStateVectorsResponseModel
    {
        /// <summary>
        /// The time which the state vectors in this response are associated with. All vectors represent the state of a vehicle with the longerval [time−1,time].
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("states")]
        public dynamic[][]? RawStates { get; set; }

        /// <summary>
        /// The state vectors.
        /// </summary>
        public List<StateVector> StateVectors
        {
            get
            {
                var result = RawStates?.Select(x => (StateVector)x)?.ToList();
                return result ?? new List<StateVector>();
            }
        }
    }
}
