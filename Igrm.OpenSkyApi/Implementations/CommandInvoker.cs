using Igrm.OpenSkyApi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Igrm.OpenSkyApi.Implementations
{
    public class CommandInvoker : IInvoker
    {
        private readonly List<ICommand> commands;

        public CommandInvoker()
        {
            commands = new List<ICommand>();
        }

        public async Task ExecuteAsync()
        {
            foreach(var command in commands)
            {
                await command.ExecuteAsync();
            }
        }

        public void SetCommand(ICommand command)
        {
            commands.Add(command);
        }
    }
}
