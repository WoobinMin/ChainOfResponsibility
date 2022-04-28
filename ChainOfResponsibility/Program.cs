using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    class Program
    {
        List<CommandHandler> commandHandlers;

        public Program()
        {
            commandHandlers = new List<CommandHandler>();

            // 1. 클래스 생성 후 CommandHandler를 상속
            // 2. 해당 클래스 구현 후 이곳 List에 Add
            commandHandlers.Add(new EchoCommand());
        }

        void DoCommand(string _command)
        {
            foreach(var i in commandHandlers)
            {
                if (i.IsSupport(_command))
                    i.Execute(_command.Split(' '));
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            string command = string.Empty;

            do
            {
                command = Console.ReadLine();
                program.DoCommand(command);
            } while (command != string.Empty);

        }
    }
}
