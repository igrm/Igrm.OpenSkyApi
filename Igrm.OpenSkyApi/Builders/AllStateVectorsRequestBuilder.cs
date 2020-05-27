using Igrm.OpenSkyApi.Interfaces;
using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IAllStateVectorsRequestBuilder : IRequestBuilder<AllStateVectorsRequestModel>
    {
        IAllStateVectorsRequestBuilder WithTime(long time);
        IAllStateVectorsRequestBuilder WithBoundingBox(decimal lamin, decimal lomin, decimal lamax, decimal lomax);
        IAllStateVectorsRequestBuilder AppendIcao24(string icao24);
    }

    public class AllStateVectorsRequestBuilder : RequestBuilderBase<AllStateVectorsRequestModel, AllStateVectorsRequestModelValidator>, IAllStateVectorsRequestBuilder
    {
        public AllStateVectorsRequestBuilder():base() {}

        public IAllStateVectorsRequestBuilder AppendIcao24(string icao24)
        {
            requestModel.Icao24.Add(icao24);
            return this;
        }

        public IAllStateVectorsRequestBuilder WithBoundingBox(decimal lamin, decimal lomin, decimal lamax, decimal lomax)
        {
            requestModel.BoundingBox.Lamin = lamin;
            requestModel.BoundingBox.Lomin = lomin;
            requestModel.BoundingBox.Lamax = lamax;
            requestModel.BoundingBox.Lomax = lomax;
            requestModel.BoundingBox.IsEmpty = false;
            return this;
        }

        public IAllStateVectorsRequestBuilder WithTime(long time)
        {
            requestModel.Time = time;
            return this;
        }
    }
}
