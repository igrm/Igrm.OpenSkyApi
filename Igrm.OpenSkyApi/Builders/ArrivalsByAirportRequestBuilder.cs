using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IArrivalsByAirportRequestBuilder : IRequestBuilder<ArrivalsByAirportRequestModel>, IInterval<IArrivalsByAirportRequestBuilder>
    {
        IArrivalsByAirportRequestBuilder WithAirport(string code);
    }

    public class ArrivalsByAirportRequestBuilder : RequestBuilderBase<ArrivalsByAirportRequestModel, ArrivalsByAirportRequestModelValidator>, IArrivalsByAirportRequestBuilder
    {
        public IArrivalsByAirportRequestBuilder WithAirport(string code)
        {
            requestModel.Airport = code;
            return this;
        }

        public IArrivalsByAirportRequestBuilder WithIntervalBegin(long time)
        {
            requestModel.Begin = time;
            return this;
        }

        public IArrivalsByAirportRequestBuilder WithIntervalEnd(long time)
        {
            requestModel.End = time;
            return this;
        }
    }
}
