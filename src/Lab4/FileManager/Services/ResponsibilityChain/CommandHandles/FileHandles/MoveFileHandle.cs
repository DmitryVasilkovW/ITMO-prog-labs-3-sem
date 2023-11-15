using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class MoveFileHandle : ConcreteCommandChainLinkBase
{
    private ICommand _command = new FileMoveCommand();
    private string _action = "move";

    public override void Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            _command.Execute();
        }
        else
        {
            Next?.Handle(request);
        }
    }
}