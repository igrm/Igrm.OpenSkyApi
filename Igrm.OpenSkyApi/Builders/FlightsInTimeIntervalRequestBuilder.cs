using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IFlightsInTimeIntervalRequestBuilder : IRequestBuilder<FlightsInTimeIntervalRequestModel>, IInterval<IFlightsInTimeIntervalRequestBuilder>
    {
    }

    public class FlightsInTimeIntervalRequestBuilder : RequestBuilderBase<FlightsInTimeIntervalRequestModel, FlightsInTimeIntervalRequestModelValidator>, IFlightsInTimeIntervalRequestBuilder
    {

        public IFlightsInTimeIntervalRequestBuilder WithIntervalBegin(long time)
        {
            requestModel.Begin = time;
            return this;
        }

        public IFlightsInTimeIntervalRequestBuilder WithIntervalEnd(long time)
        {
            requestModel.End = time;
            return this;
        }
    }
}
