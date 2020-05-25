using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igrm.OpenSkyApi.Interfaces
{
    public interface IInvoker
    {
        void SetCommand(ICommand command);
        Task ExecuteAsync();
    }
}
