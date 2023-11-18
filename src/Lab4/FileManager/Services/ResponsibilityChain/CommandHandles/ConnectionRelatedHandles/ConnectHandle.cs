using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.ConnectionRelated;

public class ConnectHandle : ConcreteCommandChainLinkBase
{
    private const int Pathposition = 0;
    private ICommand? _command;
    private string _action = "connect";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        string fullpath = request.Parameters.TrimStart().Split(' ')[Pathposition];

        if (_action.Equals(request.Action, StringComparison.Ordinal)
            && request.Parameters.TrimStart().Split(' ').Contains("-m")
            && request.Parameters.TrimStart().Split(' ').Contains("local"))
        {
            if (request.Strategy is not null) _command = new ConnectCommand(fullpath, request.Strategy);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}