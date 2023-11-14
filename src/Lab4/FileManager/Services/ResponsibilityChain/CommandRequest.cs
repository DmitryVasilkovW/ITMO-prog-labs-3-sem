namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ResponsibilityChain;

public class CommandRequest
{
    public CommandRequest(string command)
    {
        Command = command;
    }

    public string Command { get; }

    public string Type()
    {
        return Command.TrimStart().Split(' ')[0];
    }
}