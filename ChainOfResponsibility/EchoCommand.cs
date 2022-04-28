using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    class EchoCommand : CommandHandler
    {
        public void Execute(params string[] _commands)
        {
            Console.Write("Echo : ");
            for (int i = 1; i < _commands.Length; i++)
                Console.Write($"{_commands[i]} ");
            Console.WriteLine();
        }

        public bool IsSupport(string _command)
        {
            return _command.Split(' ').Length >= 2 && _command.Split(' ')[0].Equals("Echo");
        }
    }
}
