using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface ITrackByAircraftRequestBuilder : IRequestBuilder<TrackByAircraftRequestModel>
    {
        ITrackByAircraftRequestBuilder WithTime(long time);
        ITrackByAircraftRequestBuilder WithIcao24(string icao24);
    }

    public class TrackByAircraftRequestBuilder : RequestBuilderBase<TrackByAircraftRequestModel, TrackByAircraftRequestModelValidator>, ITrackByAircraftRequestBuilder
    {
        public ITrackByAircraftRequestBuilder WithIcao24(string icao24)
        {
            requestModel.Icao24 = icao24;
            return this;
        }

        public ITrackByAircraftRequestBuilder WithTime(long time)
        {
            requestModel.Time = time;
            return this;
        }
    }
}
