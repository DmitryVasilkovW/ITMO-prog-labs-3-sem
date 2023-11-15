using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;

public class ListTreeHandle : ConcreteCommandChainLinkBase
{
    private ICommand _command = new TreeListCommand();
    private string _action = "list";

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