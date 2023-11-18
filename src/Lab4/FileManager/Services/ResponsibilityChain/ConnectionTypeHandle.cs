using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class ConnectionTypeHandle : ConcreteConnectionTypeChain
{
    private string _type = "local";
    private ICommandChainLink _chain;
    public ConnectionTypeHandle(ICommandChainLink chain)
    {
        _chain = chain;
    }

    public static string? Mode { get; private set; }

    public override ICommand? Handle(CommandRequest request)
    {
        if (((IList)request.Command.TrimStart().Split(' ')).Contains("connect"))
        {
            IList<string> modearray = request.Command.Split().ToList();

            Mode = modearray[modearray.IndexOf("-m") + 1];
        }

        if (Mode is not null && Mode.Equals(_type, StringComparison.Ordinal))
        {
            if (((IList)request.Command.TrimStart().Split(' ')).Contains("disconnect")) Mode = null;
            request.Updatetrategy(new LocalFileCommands());
            return _chain.Handle(request);
        }
        else
        {
            return Next?.Handle(request);
        }
    }
}