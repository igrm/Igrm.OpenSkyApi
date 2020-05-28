using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IFlightsByAircraftRequestBuilder: IRequestBuilder<FlightsByAircraftRequestModel>, IInterval<IFlightsByAircraftRequestBuilder>
    {
        IFlightsByAircraftRequestBuilder WithIcao24(string code);
    }

    public class FlightsByAircraftRequestBuilder : RequestBuilderBase<FlightsByAircraftRequestModel, FlightsByAircraftRequestModelValidator>, IFlightsByAircraftRequestBuilder
    {
        public IFlightsByAircraftRequestBuilder WithIcao24(string code)
        {
            requestModel.Icao24 = code;
            return this;
        }

        public IFlightsByAircraftRequestBuilder WithIntervalBegin(long time)
        {
            requestModel.Begin = time;
            return this;
        }

        public IFlightsByAircraftRequestBuilder WithIntervalEnd(long time)
        {
            requestModel.End = time;
            return this;
        }
    }
}
