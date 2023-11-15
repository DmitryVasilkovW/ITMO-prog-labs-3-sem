using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles;

public class ShowFileHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "show";

    public override void Handle(ConcreteCommandRequest request)
    {
        string filepath = request.Parameters.TrimStart().Split(' ')[0];
        string modetype = request.Parameters.TrimStart().Split(' ')[1];
        string mode = request.Parameters.TrimStart().Split(' ')[3];

        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            switch (modetype)
            {
                case "-m":
                    switch (mode)
                    {
                        case "console":
                            _command = new FileConsoleShowCommand(filepath);
                            break;

                        default:
                            throw new IncorrectModeException();
                    }

                    break;
                default:
                    throw new IncorrectModeTypeException();
            }
        }
        else
        {
            Next?.Handle(request);
        }
    }
}