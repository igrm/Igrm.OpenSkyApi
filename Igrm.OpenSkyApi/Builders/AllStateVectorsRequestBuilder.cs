using Igrm.OpenSkyApi.Interfaces;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IAllStateVectorsRequestBuilder : IRequestBuilder
    {
        void WithTime(long time);
        void WithBoundingBox(decimal lamin, decimal lomin, decimal lamax, decimal lomax);
        void AppendIcao24(string icao24);
    }

    public class AllStateVectorsRequestBuilder : RequestBuilderBase<AllStateVectorsRequestModel, AllStateVectorsRequestModelValidator>, IAllStateVectorsRequestBuilder
    {
        public AllStateVectorsRequestBuilder():base() {}

        public void AppendIcao24(string icao24)
        {
            requestModel.Icao24.Add(icao24);
        }

        public void WithBoundingBox(decimal lamin, decimal lomin, decimal lamax, decimal lomax)
        {
           requestModel.BoundingBox.Lamin = lamin;
           requestModel.BoundingBox.Lomin = lomin;
           requestModel.BoundingBox.Lamax = lamax;
           requestModel.BoundingBox.Lomax = lomax;
           requestModel.BoundingBox.IsEmpty = false;
        }

        public void WithTime(long time)
        {
            requestModel.Time = time;
        }
    }
}
