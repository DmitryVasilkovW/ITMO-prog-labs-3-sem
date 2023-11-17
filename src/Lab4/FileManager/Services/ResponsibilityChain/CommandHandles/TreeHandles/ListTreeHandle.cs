using System;
using System.Collections;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain.CommandHandles.TreeHandles;

public class ListTreeHandle : ConcreteCommandChainLinkBase
{
    private ICommand? _command;
    private string _action = "list";

    public override ICommand? Handle(ConcreteCommandRequest request)
    {
        if (_action.Equals(request.Action, StringComparison.Ordinal))
        {
            if (((IList)request.Parameters.TrimStart().Split(' ')).Contains("-d"))
            {
                string depth = request.Parameters.Replace("-d", string.Empty, StringComparison.Ordinal);

                _command = new TreeListCommand();
                ((TreeListCommand)_command).UpdateDepth(int.Parse(depth, System.Globalization.CultureInfo.InvariantCulture));
                return _command;
            }

            _command = new TreeListCommand();
            return _command;
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}