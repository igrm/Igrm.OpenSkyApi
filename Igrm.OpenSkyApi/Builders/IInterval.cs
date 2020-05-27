using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IInterval
    {
        void WithIntervalBegin(long time);
        void WithIntervalEnd(long time);
    }
}
