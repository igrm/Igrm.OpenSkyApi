using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IFlightsByAircraftRequestBuilder: IRequestBuilder<FlightsByAircraftRequestModel>, IInterval
    {
        void WithIcao24(string code);
    }

    public class FlightsByAircraftRequestBuilder : RequestBuilderBase<FlightsByAircraftRequestModel, FlightsByAircraftRequestModelValidator>, IFlightsByAircraftRequestBuilder
    {
        public void WithIcao24(string code)
        {
            requestModel.Icao24 = code;
        }

        public void WithIntervalBegin(long time)
        {
            requestModel.Begin = time;
        }

        public void WithIntervalEnd(long time)
        {
            requestModel.End = time;
        }
    }
}
