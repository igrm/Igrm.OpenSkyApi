using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IOwnStateVectorsRequestBuilder : IRequestBuilder<OwnStateVectorsRequestModel>
    {
        IOwnStateVectorsRequestBuilder AppendIcao24(string code);
        IOwnStateVectorsRequestBuilder AppendSerial(long item);
        IOwnStateVectorsRequestBuilder WithTime(long time);
    }

    public class OwnStateVectorsRequestBuilder : RequestBuilderBase<OwnStateVectorsRequestModel, OwnStateVectorsRequestModelValidator>, IOwnStateVectorsRequestBuilder
    {
        public IOwnStateVectorsRequestBuilder AppendIcao24(string code)
        {
            requestModel.Icao24.Add(code);
            return this;
        }

        public IOwnStateVectorsRequestBuilder AppendSerial(long item)
        {
            requestModel.Serials.Add(item);
            return this;
        }

        public IOwnStateVectorsRequestBuilder WithTime(long time)
        {
            requestModel.Time = time;
            return this;
        }
    }
}
