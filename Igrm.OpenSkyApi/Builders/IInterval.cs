using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IInterval<T>
    {
        T WithIntervalBegin(long time);
        T WithIntervalEnd(long time);
    }
}
