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
            _command = new FileDeleteCommand(filepath);
            return _command;
        }
        else
        {
            Next?.Handle(request);
        }

        return _command;
    }
}