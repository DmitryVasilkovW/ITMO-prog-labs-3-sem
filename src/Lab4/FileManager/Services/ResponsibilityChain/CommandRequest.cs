using Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class CommandRequest
{
    public CommandRequest(string command)
    {
        Command = command;
    }

    public string Command { get; }

    public ICommandStrategy? Strategy { get; private set; }

    public string Type()
    {
        return Command.TrimStart().Split(' ')[0];
    }

    public void Updatetrategy(ICommandStrategy strategy)
    {
        Strategy = strategy;
    }
}