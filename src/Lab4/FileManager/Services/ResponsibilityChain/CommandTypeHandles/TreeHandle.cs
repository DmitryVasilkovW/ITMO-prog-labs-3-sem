using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class TreeHandle : CommandChainLinkBase
{
    private string _type = "tree";
    private IConcreteCommandChainLink _chain;

    public TreeHandle(IConcreteCommandChainLink chain)
    {
        _chain = chain;
    }

    public override ICommand? Handle(CommandRequest request)
    {
        if (request.Type().Equals(_type, StringComparison.Ordinal))
        {
            string action = request.Command.TrimStart().Split(' ')[1];
            string parameters = string.Empty;

            for (int i = 2; i < request.Command.TrimStart().Split(' ').Length; i++)
            {
                parameters += request.Command.TrimStart().Split(' ')[i] + " ";
            }

            return _chain.Handle(new ConcreteCommandRequest(action, parameters, request.Strategy));
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}