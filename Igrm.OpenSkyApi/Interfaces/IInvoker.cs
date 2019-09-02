using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Interfaces
{
    public interface IInvoker
    {
        void SetCommand(ICommand command);
        void Execute();
    }
}
