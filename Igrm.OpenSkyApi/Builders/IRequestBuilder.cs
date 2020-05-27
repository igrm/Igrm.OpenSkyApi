using Igrm.OpenSkyApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Builders
{
    public interface IRequestBuilder<T>
    {
        T Build();
    }
}
