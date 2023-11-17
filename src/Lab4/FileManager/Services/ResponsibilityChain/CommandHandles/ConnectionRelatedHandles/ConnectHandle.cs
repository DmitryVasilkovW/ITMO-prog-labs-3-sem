using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.ConnectionRelated;

public class ConnectHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "connect";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        string fullpath = request.Parameters.TrimStart().Split(' ')[0];
        string modetype = request.Parameters.TrimStart().Split(' ')[1];
        string mode = request.Parameters.TrimStart().Split(' ')[2];

        if (_action.Equals(request.Action, StringComparison.Ordinal)
            && modetype.Equals("-m", StringComparison.Ordinal)
            && mode.Equals("local", StringComparison.Ordinal))
        {
            _command = new ConnectCommand(fullpath);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}