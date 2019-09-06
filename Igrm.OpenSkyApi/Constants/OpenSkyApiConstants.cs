using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Constants
{
    public class OpenSkyApiConstants
    {
        public const String PROTOCOL = "https://";
        public const String HOST = "opensky-network.org";
        public const String API_ROOT = "/api";
        public const String AVAILABLE_STATES = "/states/all";
        public const String SPECIFIED_USER_STATES = "/states/own";
        public const String ALL_FLIGHTS_IN_INTERVAL = "/flights/all";
        public const String SPECIFIED_AIRCRAFT_FLIGHTS_IN_INTERVAL = "/flights/aircraft";
        public const String SPECIFIED_AIRCRAFT_TRACK = "/tracks";
        public const String AIRPORT_ARRIVALS = "/flights/arrival";
        public const String AIRPORT_DEPARTURES = "/flights/departure";

    }
}
