using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class ConcreteCommandRequest
{
    public ConcreteCommandRequest(string action, string parameters, ICommandStrategy? strategy)
    {
        Action = action;
        Parameters = parameters;
        Strategy = strategy;
    }

    public string Action { get; }

    public ICommandStrategy? Strategy { get; }

    public string Parameters { get; }
}