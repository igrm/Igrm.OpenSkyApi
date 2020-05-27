using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IDeparturesByAirportRequestBuilder : IRequestBuilder<DeparturesByAirportRequestModel>, IInterval
    {
        void WithAirport(string code);
    }

    public class DeparturesByAirportRequestBuilder : RequestBuilderBase<DeparturesByAirportRequestModel, DeparturesByAirportRequestModelValidator>, IDeparturesByAirportRequestBuilder
    {
        public void WithAirport(string code)
        {
            requestModel.Airport = code;
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
