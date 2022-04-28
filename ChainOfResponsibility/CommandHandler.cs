using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public interface CommandHandler
    {
        bool IsSupport(string _command);
        void Execute(params string[] _commands);
    }
}
