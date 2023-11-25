using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class CopyFileHandle : ConcreteCommandChainLinkBase
{
    private const int FilePathposition = 0;
    private const int Directorypathposition = 1;
    private ICommand? _command;
    private string _action = "copy";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            string filepath = request.Parameters.TrimStart().Split(' ')[FilePathposition];
            string directorypath = request.Parameters.TrimStart().Split(' ')[Directorypathposition];

            if (request.Strategy is not null) _command = new FileCopyCommand(filepath, directorypath, request.Strategy);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}