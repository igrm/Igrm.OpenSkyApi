﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Response
{
    public class FlightsInTimeIntervalResponseModel
    {
        ///<summary>
        ///Unique ICAO 24-bit address of the transponder in hex string representation. All letters are lower case.
        ///</summary>
        public string Icao24 { get; set; }
        ///<summary>
        ///Estimated time of departure for the flight as Unix time (seconds since epoch).
        ///</summary>
        public int Firstseen { get; set; }
        ///<summary>
        ///ICAO code of the estimated departure airport. Can be null if the airport could not be identified.
        ///</summary>
        public string Estdepartureairport { get; set; }
        ///<summary>
        ///Estimated time of arrival for the flight as Unix time (seconds since epoch)
        ///</summary>
        public int Lastseen { get; set; }
        ///<summary>
        ///ICAO code of the estimated arrival airport. Can be null if the airport could not be identified.
        ///</summary>
        public string Estarrivalairport { get; set; }
        ///<summary>
        ///Callsign of the vehicle (8 chars). Can be null if no callsign has been received. If the vehicle transmits multiple callsigns during the flight, we take the one seen most frequently
        ///</summary>
        public string Callsign { get; set; }
        ///<summary>
        ///Horizontal distance of the last received airborne position to the estimated departure airport in meters
        ///</summary>
        public int Estdepartureairporthorizdistance { get; set; }
        ///<summary>
        ///Vertical distance of the last received airborne position to the estimated departure airport in meters
        ///</summary>
        public int Estdepartureairportvertdistance { get; set; }
        ///<summary>
        ///Horizontal distance of the last received airborne position to the estimated arrival airport in meters
        ///</summary>
        public int Estarrivalairporthorizdistance { get; set; }
        ///<summary>
        ///Vertical distance of the last received airborne position to the estimated arrival airport in meters
        ///</summary>
        public int Estarrivalairportvertdistance { get; set; }
        ///<summary>
        ///Number of other possible departure airports. These are airports in short distance to estDepartureAirport.
        ///</summary>
        public int Departureairportcandidatescount { get; set; }
        ///<summary>
        ///Number of other possible departure airports. These are airports in short distance to estArrivalAirport.
        ///</summary>
        public int Arrivalairportcandidatescount { get; set; }

    }
}