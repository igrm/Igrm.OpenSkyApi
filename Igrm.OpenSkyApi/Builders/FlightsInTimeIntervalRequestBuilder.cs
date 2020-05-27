using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IFlightsInTimeIntervalRequestBuilder : IRequestBuilder<FlightsInTimeIntervalRequestModel>, IInterval
    {

    }

    public class FlightsInTimeIntervalRequestBuilder : RequestBuilderBase<FlightsInTimeIntervalRequestModel, FlightsInTimeIntervalRequestModelValidator>, IFlightsInTimeIntervalRequestBuilder
    {

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
