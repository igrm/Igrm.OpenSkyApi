using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IDeparturesByAirportRequestBuilder : IRequestBuilder<DeparturesByAirportRequestModel>, IInterval<IDeparturesByAirportRequestBuilder>
    {
        IDeparturesByAirportRequestBuilder WithAirport(string code);
    }

    public class DeparturesByAirportRequestBuilder : RequestBuilderBase<DeparturesByAirportRequestModel, DeparturesByAirportRequestModelValidator>, IDeparturesByAirportRequestBuilder
    {
        public IDeparturesByAirportRequestBuilder WithAirport(string code)
        {
            requestModel.Airport = code;
            return this;
        }

        public IDeparturesByAirportRequestBuilder WithIntervalBegin(long time)
        {
            requestModel.Begin = time;
            return this;
        }

        public IDeparturesByAirportRequestBuilder WithIntervalEnd(long time)
        {
            requestModel.End = time;
            return this;
        }
    }
}
