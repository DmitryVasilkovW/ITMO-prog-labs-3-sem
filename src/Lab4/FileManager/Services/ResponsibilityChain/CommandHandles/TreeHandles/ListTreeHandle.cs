using System;
using System.Collections;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;

public class ListTreeHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "list";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal) && request.Parameters.TrimStart().Split(' ').Contains("console"))
        {
            if (((IList)request.Parameters.TrimStart().Split(' ')).Contains("-d"))
            {
                string depth = request.Parameters.Replace("-d", string.Empty, StringComparison.Ordinal);

                if (request.Strategy is not null) _command = new TreeListCommand(request.Strategy, new ConsolePrint());
                if (_command is not null) ((TreeListCommand)_command).UpdateDepth(int.Parse(depth, System.Globalization.CultureInfo.InvariantCulture));
                return _command;
            }

            if (request.Strategy is not null) _command = new TreeListCommand(request.Strategy, new ConsolePrint());
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}