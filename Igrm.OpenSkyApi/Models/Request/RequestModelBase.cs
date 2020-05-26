using Igrm.OpenSkyApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Request
{
    public abstract class RequestModelBase : IRequestModel
    {
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
