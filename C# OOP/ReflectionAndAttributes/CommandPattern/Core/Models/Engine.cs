using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private ICommandInterpreter _commandInterpreter;
        public Engine(ICommandInterpreter command)
        {
            this._commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                string result = _commandInterpreter.Read(command);

                if (result == null)
                {
                    break;
                }
                
                Console.WriteLine(result);
            }
        }
    }
}