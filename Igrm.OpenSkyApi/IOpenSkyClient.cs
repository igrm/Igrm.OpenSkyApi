using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi
{
    public interface IOpenSkyClient
    {
        AllStateVectorsResponseModel GetAllStateVectors(AllStateVectorsRequestModel requestModel);
        OwnStateVectorsResponseModel GetOwnStateVectors(OwnStateVectorsRequestModel requestModel);
        FlightsByAircraftResponseModel GetFlightsByAircraft(FlightsByAircraftRequestModel requestModel);
        FlightsInTimeIntervalResponseModel GetFlightsInTimeInterval(FlightsInTimeIntervalRequestModel requestModel);
        ArrivalsByAirportResponseModel GetArrivalsByAirport(ArrivalsByAirportRequestModel requestModel);
        DeparturesByAirportResponseModel GetDeparturesByAirport(DeparturesByAirportRequestModel requestModel);
        TrackByAircraftResponseModel GetTrackByAircraft(TrackByAircraftRequestModel requestModel);
    }
}
