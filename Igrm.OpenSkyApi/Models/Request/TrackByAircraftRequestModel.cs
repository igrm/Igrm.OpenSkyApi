﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public class TrackByAircraftRequestModel
    {
        /// <summary>
        /// Unique ICAO 24-bit address of the transponder in hex string representation. All letters need to be lower case
        /// </summary>
        public String Icao24 { get; set; }

        /// <summary>
        /// Unix time in seconds since epoch. It can be any time between start and end of a known flight. If time = 0, get the live track if there is any flight ongoing for the given aircraft.
        /// </summary>
        public int? Time { get; set; }
    }
}
