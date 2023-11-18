using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class ShowFileHandle : ConcreteCommandChainLinkBase
{
    private const int FilePathposition = 0;
    private ICommand? _command;
    private string _action = "show";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        string filepath = request.Parameters.TrimStart().Split(' ')[FilePathposition];

        if (_action.Equals(request.Action, StringComparison.Ordinal)
            && ((IList)request.Parameters.TrimStart().Split(' ')).Contains("-m")
            && ((IList)request.Parameters.TrimStart().Split(' ')).Contains("console"))
        {
            if (request.Strategy is not null) _command = new FileConsoleShowCommand(filepath, request.Strategy);
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}