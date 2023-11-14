namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class ConcreteCommandRequest
{
    public ConcreteCommandRequest(string action, string parameters)
    {
        Action = action;
        Parameters = parameters;
    }

    public string Action { get; }

    public string Parameters { get; }
}