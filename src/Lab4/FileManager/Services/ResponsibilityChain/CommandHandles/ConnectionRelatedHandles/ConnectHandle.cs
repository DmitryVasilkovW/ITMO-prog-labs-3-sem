using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.ConnectionRelated;

public class ConnectHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "connect";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            string fullpath = request.Parameters.TrimStart().Split(' ')[0];
            string modetype = request.Parameters.TrimStart().Split(' ')[1];
            string mode = request.Parameters.TrimStart().Split(' ')[3];

            switch (modetype)
            {
                case "-m":
                    switch (mode)
                    {
                        case "local":
                            _command = new ConnectCommand(fullpath);
                            return _command;

                        default:
                            throw new IncorrectModeException();
                    }

                default:
                    throw new IncorrectModeTypeException();
            }
        }
        else
        {
            Next?.Handle(request);
        }

        return null;
    }
}