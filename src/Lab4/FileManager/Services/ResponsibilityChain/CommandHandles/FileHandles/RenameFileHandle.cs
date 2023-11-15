using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class RenameFileHandle : ConcreteCommandChainLinkBase
{
    private ICommand _command = new FileRenameCommand();
    private string _action = "remane";

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