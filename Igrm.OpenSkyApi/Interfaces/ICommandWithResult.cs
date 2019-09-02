using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Interfaces
{
    public interface ICommandWithResult<T> : ICommand
    {
        T Result { get; }
    }
}
