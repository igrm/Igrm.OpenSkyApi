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

        public AllStateVectorsResponseModel GetAllStateVectors(AllStateVectorsRequestModel requestModel)
        {
            var command = new AllStateVectorsCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<AllStateVectorsRequestModel, AllStateVectorsCommand, AllStateVectorsResponseModel>(command);
        }

        public ArrivalsByAirportResponseModel GetArrivalsByAirport(ArrivalsByAirportRequestModel requestModel)
        {
            var command = new ArrivalsByAirportCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<ArrivalsByAirportResponseModel, ArrivalsByAirportCommand, ArrivalsByAirportResponseModel>(command);
        }

        public DeparturesByAirportResponseModel GetDeparturesByAirport(DeparturesByAirportRequestModel requestModel)
        {
            var command = new DeparturesByAirportCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<DeparturesByAirportResponseModel, DeparturesByAirportCommand, DeparturesByAirportResponseModel>(command);
        }

        public FlightsByAircraftResponseModel GetFlightsByAircraft(FlightsByAircraftRequestModel requestModel)
        {
            var command = new FlightsByAircraftCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<FlightsByAircraftResponseModel, FlightsByAircraftCommand, FlightsByAircraftResponseModel>(command);
        }

        public FlightsInTimeIntervalResponseModel GetFlightsInTimeInterval(FlightsInTimeIntervalRequestModel requestModel)
        {
            var command = new FlightsInTimeIntervalCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<FlightsInTimeIntervalRequestModel, FlightsInTimeIntervalCommand, FlightsInTimeIntervalResponseModel>(command);
        }

        public OwnStateVectorsResponseModel GetOwnStateVectors(OwnStateVectorsRequestModel requestModel)
        {
            var command = new OwnStateVectorsCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<OwnStateVectorsRequestModel, OwnStateVectorsCommand, OwnStateVectorsResponseModel>(command);
        }

        public TrackByAircraftResponseModel GetTrackByAircraft(TrackByAircraftRequestModel requestModel)
        {
            var command = new TrackByAircraftCommand(_httpClient, _basicAuthenticationHeader, requestModel);
            return Get<TrackByAircraftRequestModel, TrackByAircraftCommand, TrackByAircraftResponseModel>(command);
        }
    }
}
