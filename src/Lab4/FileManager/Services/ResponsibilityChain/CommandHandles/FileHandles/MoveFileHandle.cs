using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class MoveFileHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "move";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            string filepath = request.Parameters.TrimStart().Split(' ')[0];
            string directorypath = request.Parameters.TrimStart().Split(' ')[1];

            _command = new FileMoveCommand(filepath, directorypath);
            return _command;
        }
        else
        {
            Next?.Handle(request);
        }

        return _command;
    }
}