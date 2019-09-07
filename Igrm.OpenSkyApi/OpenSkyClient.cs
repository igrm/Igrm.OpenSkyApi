using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Igrm.OpenSkyApi.Implementations;
using Igrm.OpenSkyApi.Interfaces;
using Igrm.OpenSkyApi.Models;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;

namespace Igrm.OpenSkyApi
{
    /// <summary>
    /// OpenSky API .NET Client implementation
    /// Please refer to https://opensky-network.org/apidoc/rest.html for more details.
    /// </summary>
    public class OpenSkyClient : IOpenSkyClient
    {
        private readonly HttpClient _httpClient;
        private readonly BasicAuthenticationHeader _basicAuthenticationHeader;
        private readonly IInvoker _invoker;

        public OpenSkyClient(HttpClient httpClient) : this(httpClient, String.Empty, String.Empty)
        {
        }

        public OpenSkyClient(HttpClient httpClient, string username, string password)
        {
            _httpClient = httpClient;

            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                _basicAuthenticationHeader = new BasicAuthenticationHeader() { Username = username, Password = password };
            }

            _invoker = new CommandInvoker();
        }

        private V Get<T, U, V>(U command) where U:ICommandWithResult<V>
        {
            _invoker.SetCommand(command);
            _invoker.Execute();
            return command.Result;
        }

        /// <summary>
        /// The following API call can be used to retrieve any state vector of the OpenSky. Please note that rate limits apply for this call (see Limitations). For API calls without rate limitation, see Own State Vectors.
        /// </summary>
        public AllStateVectorsResponseModel GetAllStateVectors(AllStateVectorsRequestModel requestModel)
        {
            var command = new AllStateVectorsCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<AllStateVectorsRequestModel, AllStateVectorsCommand, AllStateVectorsResponseModel>(command);
        }

        /// <summary>
        /// Retrieve flights for a certain airport which arrived within a given time interval [begin, end]. If no flights are found for the given period, HTTP stats 404 - Not found is returned with an empty response body.
        /// </summary>
        public ArrivalsByAirportResponseModel GetArrivalsByAirport(ArrivalsByAirportRequestModel requestModel)
        {
            var command = new ArrivalsByAirportCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<ArrivalsByAirportResponseModel, ArrivalsByAirportCommand, ArrivalsByAirportResponseModel>(command);
        }

        /// <summary>
        /// Retrieve flights for a certain airport which departed within a given time interval [begin, end]. If no flights are found for the given period, HTTP stats 404 - Not found is returned with an empty response body.
        /// </summary>
        public DeparturesByAirportResponseModel GetDeparturesByAirport(DeparturesByAirportRequestModel requestModel)
        {
            var command = new DeparturesByAirportCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<DeparturesByAirportResponseModel, DeparturesByAirportCommand, DeparturesByAirportResponseModel>(command);
        }

        /// <summary>
        /// This API call retrieves flights for a particular aircraft within a certain time interval. Resulting flights departed and arrived within [begin, end]. If no flights are found for the given period, HTTP stats 404 - Not found is returned with an empty response body.
        /// </summary>
        public FlightsByAircraftResponseModel GetFlightsByAircraft(FlightsByAircraftRequestModel requestModel)
        {
            var command = new FlightsByAircraftCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<FlightsByAircraftResponseModel, FlightsByAircraftCommand, FlightsByAircraftResponseModel>(command);
        }

        /// <summary>
        /// This API call retrieves flights for a certain time interval [begin, end]. If no flights are found for the given time period, HTTP status 404 - Not found is returned with an empty response body.
        /// </summary>
        public FlightsInTimeIntervalResponseModel GetFlightsInTimeInterval(FlightsInTimeIntervalRequestModel requestModel)
        {
            var command = new FlightsInTimeIntervalCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<FlightsInTimeIntervalRequestModel, FlightsInTimeIntervalCommand, FlightsInTimeIntervalResponseModel>(command);
        }

        /// <summary>
        /// The following API call can be used to retrieve state vectors for your own sensors without rate limitations. Note that authentication is required for this operation, otherwise you will get a 403 - Forbidden.
        /// </summary>
        public OwnStateVectorsResponseModel GetOwnStateVectors(OwnStateVectorsRequestModel requestModel)
        {
            var command = new OwnStateVectorsCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<OwnStateVectorsRequestModel, OwnStateVectorsCommand, OwnStateVectorsResponseModel>(command);
        }

        /// <summary>
        /// Retrieve the trajectory for a certain aircraft at a given time. The trajectory is a list of waypoints containing position, barometric altitude, true track and an on-ground flag.
        /// </summary>
        public TrackByAircraftResponseModel GetTrackByAircraft(TrackByAircraftRequestModel requestModel)
        {
            var command = new TrackByAircraftCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<TrackByAircraftRequestModel, TrackByAircraftCommand, TrackByAircraftResponseModel>(command);
        }
    }
}
