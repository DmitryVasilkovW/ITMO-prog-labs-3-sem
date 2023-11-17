using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;

public class ListTreeHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "list";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        string modetype = request.Parameters.TrimStart().Split(' ')[0];

        // int mode = int.Parse(request.Parameters.TrimStart().Split(' ')[1], NumberStyles.Integer);
        if (_action.Equals(request.Action, StringComparison.Ordinal)
            && modetype.Equals("-d", StringComparison.Ordinal))
        {
            _command = new TreeListCommand();
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}