using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class DisconnectHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "disconnect";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            if (request.Strategy is not null) _command = new DisconnectCommand(request.Strategy);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}