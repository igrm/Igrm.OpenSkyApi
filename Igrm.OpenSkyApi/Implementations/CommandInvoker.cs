using Igrm.OpenSkyApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Implementations
{
    public class CommandInvoker : IInvoker
    {
        private List<ICommand> commands;

        public CommandInvoker()
        {
            commands = new List<ICommand>();
        }

        public void Execute()
        {
            foreach(var command in commands)
            {
                command.Execute();
            }
        }

        public void SetCommand(ICommand command)
        {
            commands.Add(command);
        }
    }
}
