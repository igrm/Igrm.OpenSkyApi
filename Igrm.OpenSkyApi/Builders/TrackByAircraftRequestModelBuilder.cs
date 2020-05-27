using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface ITrackByAircraftRequestModelBuilder
    {
        void WithTime(long time);
        void WithIcao24(string icao24);
    }

    public class TrackByAircraftRequestModelBuilder : RequestBuilderBase<TrackByAircraftRequestModel, TrackByAircraftRequestModelValidator>, ITrackByAircraftRequestModelBuilder
    {
        public void WithIcao24(string icao24)
        {
            requestModel.Icao24 = icao24;
        }

        public void WithTime(long time)
        {
            requestModel.Time = time;
        }
    }
}
