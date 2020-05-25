using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        private async Task<U> GetAsync<R, T, U>(R request) where T : ICommandWithResult<U>
                                                           where R : IRequestModel
        {
            var command = (T)Activator.CreateInstance(typeof(T), _httpClient, _basicAuthenticationHeader, request);
            _invoker.SetCommand(command);
            await _invoker.ExecuteAsync();
            return command.Result;
        }

        #region Async methods
        /// <summary>
        /// The following API call can be used to retrieve any state vector of the OpenSky. Please note that rate limits apply for this call (see Limitations). For API calls without rate limitation, see Own State Vectors.
        /// </summary>
        public async Task<AllStateVectorsResponseModel> GetAllStateVectorsAsync(AllStateVectorsRequestModel requestModel)
        {
            return await GetAsync<AllStateVectorsRequestModel, AllStateVectorsCommand, AllStateVectorsResponseModel>(requestModel);
        }

        /// <summary>
        /// Retrieve flights for a certain airport which arrived within a given time interval [begin, end]. If no flights are found for the given period, HTTP stats 404 - Not found is returned with an empty response body.
        /// </summary>
        public async Task<ArrivalsByAirportResponseModel> GetArrivalsByAirportAsync(ArrivalsByAirportRequestModel requestModel)
        {
             return await GetAsync<ArrivalsByAirportRequestModel, ArrivalsByAirportCommand, ArrivalsByAirportResponseModel>(requestModel);
        }

        /// <summary>
        /// Retrieve flights for a certain airport which departed within a given time interval [begin, end]. If no flights are found for the given period, HTTP stats 404 - Not found is returned with an empty response body.
        /// </summary>
        public async Task<DeparturesByAirportResponseModel> GetDeparturesByAirportAsync(DeparturesByAirportRequestModel requestModel)
        {
            return await GetAsync<DeparturesByAirportRequestModel, DeparturesByAirportCommand, DeparturesByAirportResponseModel>(requestModel);
        }

        /// <summary>
        /// This API call retrieves flights for a particular aircraft within a certain time interval. Resulting flights departed and arrived within [begin, end]. If no flights are found for the given period, HTTP stats 404 - Not found is returned with an empty response body.
        /// </summary>
        public async Task<FlightsByAircraftResponseModel> GetFlightsByAircraftAsync(FlightsByAircraftRequestModel requestModel)
        {
            return await GetAsync<FlightsByAircraftRequestModel, FlightsByAircraftCommand, FlightsByAircraftResponseModel>(requestModel);
        }

        /// <summary>
        /// This API call retrieves flights for a certain time interval [begin, end]. If no flights are found for the given time period, HTTP status 404 - Not found is returned with an empty response body.
        /// </summary>
        public async Task<FlightsInTimeIntervalResponseModel> GetFlightsInTimeIntervalAsync(FlightsInTimeIntervalRequestModel requestModel)
        {
            return await GetAsync<FlightsInTimeIntervalRequestModel, FlightsInTimeIntervalCommand, FlightsInTimeIntervalResponseModel>(requestModel);
        }

        /// <summary>
        /// The following API call can be used to retrieve state vectors for your own sensors without rate limitations. Note that authentication is required for this operation, otherwise you will get a 403 - Forbidden.
        /// </summary>
        public async Task<OwnStateVectorsResponseModel> GetOwnStateVectorsAsync(OwnStateVectorsRequestModel requestModel)
        {
            return await GetAsync<OwnStateVectorsRequestModel, OwnStateVectorsCommand, OwnStateVectorsResponseModel>(requestModel);
        }

        /// <summary>
        /// Retrieve the trajectory for a certain aircraft at a given time. The trajectory is a list of waypoints containing position, barometric altitude, true track and an on-ground flag.
        /// </summary>
        public async Task<TrackByAircraftResponseModel> GetTrackByAircraftAsync(TrackByAircraftRequestModel requestModel)
        {
            return await GetAsync<TrackByAircraftRequestModel, TrackByAircraftCommand, TrackByAircraftResponseModel>(requestModel);
        }

        #endregion

        #region Sync methods
        public AllStateVectorsResponseModel GetAllStateVectors(AllStateVectorsRequestModel requestModel)
        {
            return GetAllStateVectorsAsync(requestModel).Result;
        }

        public OwnStateVectorsResponseModel GetOwnStateVectors(OwnStateVectorsRequestModel requestModel)
        {
            return GetOwnStateVectorsAsync(requestModel).Result;
        }

        public FlightsByAircraftResponseModel GetFlightsByAircraft(FlightsByAircraftRequestModel requestModel)
        {
            return GetFlightsByAircraftAsync(requestModel).Result;
        }

        public FlightsInTimeIntervalResponseModel GetFlightsInTimeInterval(FlightsInTimeIntervalRequestModel requestModel)
        {
            return GetFlightsInTimeIntervalAsync(requestModel).Result;
        }

        public ArrivalsByAirportResponseModel GetArrivalsByAirport(ArrivalsByAirportRequestModel requestModel)
        {
            return GetArrivalsByAirportAsync(requestModel).Result;
        }

        public DeparturesByAirportResponseModel GetDeparturesByAirport(DeparturesByAirportRequestModel requestModel)
        {
            return GetDeparturesByAirportAsync(requestModel).Result;
        }

        public TrackByAircraftResponseModel GetTrackByAircraft(TrackByAircraftRequestModel requestModel)
        {
            return GetTrackByAircraftAsync(requestModel).Result;
        }

        #endregion
    }
}
