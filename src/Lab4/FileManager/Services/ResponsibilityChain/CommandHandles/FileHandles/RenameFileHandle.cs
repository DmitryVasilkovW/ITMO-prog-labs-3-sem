using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class RenameFileHandle : ConcreteCommandChainLinkBase
{
    private const int FilePathposition = 0;
    private const int Nameposition = 1;
    private ICommand? _command;
    private string _action = "rename";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            string filepath = request.Parameters.TrimStart().Split(' ')[FilePathposition];
            string newname = request.Parameters.TrimStart().Split(' ')[Nameposition];

            if (request.Strategy is not null) _command = new FileRenameCommand(filepath, newname, request.Strategy);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}