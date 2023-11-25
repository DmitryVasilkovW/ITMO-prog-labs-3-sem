namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class DisconnectCommand : ICommand
{
    private ICommandStrategy _strategy;

    public DisconnectCommand(ICommandStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Execute(ref string? path)
    {
        _strategy.Disconnect(ref path);
    }
}