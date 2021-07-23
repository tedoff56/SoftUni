using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";
            
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            Type commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}{CommandSuffix}");
            
            ICommand command = Activator.CreateInstance(commandType) as ICommand;
            
            
            return command?.Execute(commandArgs);
        }
    }
}