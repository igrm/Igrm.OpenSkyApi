using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenSkyApi
{
    public interface IOpenSkyClient
    {
        Task<AllStateVectorsResponseModel> GetAllStateVectorsAsync(AllStateVectorsRequestModel requestModel);
        AllStateVectorsResponseModel GetAllStateVectors(AllStateVectorsRequestModel requestModel);

        Task<OwnStateVectorsResponseModel> GetOwnStateVectorsAsync(OwnStateVectorsRequestModel requestModel);
        OwnStateVectorsResponseModel GetOwnStateVectors(OwnStateVectorsRequestModel requestModel);

        Task<FlightsByAircraftResponseModel> GetFlightsByAircraftAsync(FlightsByAircraftRequestModel requestModel);
        FlightsByAircraftResponseModel GetFlightsByAircraft(FlightsByAircraftRequestModel requestModel);
        
        Task<FlightsInTimeIntervalResponseModel> GetFlightsInTimeIntervalAsync(FlightsInTimeIntervalRequestModel requestModel);
        FlightsInTimeIntervalResponseModel GetFlightsInTimeInterval(FlightsInTimeIntervalRequestModel requestModel);

        Task<ArrivalsByAirportResponseModel> GetArrivalsByAirportAsync(ArrivalsByAirportRequestModel requestModel);
        ArrivalsByAirportResponseModel GetArrivalsByAirport(ArrivalsByAirportRequestModel requestModel);

        Task<DeparturesByAirportResponseModel> GetDeparturesByAirportAsync(DeparturesByAirportRequestModel requestModel);
        DeparturesByAirportResponseModel GetDeparturesByAirport(DeparturesByAirportRequestModel requestModel);

        Task<TrackByAircraftResponseModel> GetTrackByAircraftAsync(TrackByAircraftRequestModel requestModel);
        TrackByAircraftResponseModel GetTrackByAircraft(TrackByAircraftRequestModel requestModel);
    }
}
