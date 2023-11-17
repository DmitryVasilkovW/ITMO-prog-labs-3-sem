namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(ref string? path)
    {
        path = null;
    }
}