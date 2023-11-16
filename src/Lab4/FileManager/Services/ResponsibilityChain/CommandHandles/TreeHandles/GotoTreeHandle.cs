using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;

public class GotoTreeHandle : ConcreteCommandChainLinkBase
{
    private ICommand _command = new TreeGotoCommand();
    private string _action = "goto";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            return _command;
        }
        else
        {
            Next?.Handle(request);
        }

        return _command;
    }
}