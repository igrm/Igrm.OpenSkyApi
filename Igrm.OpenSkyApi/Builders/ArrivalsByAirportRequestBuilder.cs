using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IArrivalsByAirportRequestBuilder : IRequestBuilder<ArrivalsByAirportRequestModel>, IInterval
    {
        void WithAirport(string code);
    }

    public class ArrivalsByAirportRequestBuilder : RequestBuilderBase<ArrivalsByAirportRequestModel, ArrivalsByAirportRequestModelValidator>, IArrivalsByAirportRequestBuilder
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
