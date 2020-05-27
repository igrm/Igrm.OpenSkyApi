using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IOwnStateVectorsRequestBuilder : IRequestBuilder<OwnStateVectorsRequestModel>
    {
        void AppendIcao24(string code);
        void AppendSerial(long item);
        void WithTime(long time);
    }

    public class OwnStateVectorsRequestBuilder : RequestBuilderBase<OwnStateVectorsRequestModel, OwnStateVectorsRequestModelValidator>, IOwnStateVectorsRequestBuilder
    {
        public void AppendIcao24(string code)
        {
            requestModel.Icao24.Add(code);
        }

        public void AppendSerial(long item)
        {
            requestModel.Serials.Add(item);
        }

        public void WithTime(long time)
        {
            requestModel.Time = time;
        }
    }
}
