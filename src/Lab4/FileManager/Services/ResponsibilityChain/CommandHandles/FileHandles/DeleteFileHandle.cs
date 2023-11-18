using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class DeleteFileHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "delete";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            string filepath = request.Parameters;
            if (request.Strategy is not null) _command = new FileDeleteCommand(filepath, request.Strategy);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}