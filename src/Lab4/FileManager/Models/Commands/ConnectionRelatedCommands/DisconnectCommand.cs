namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class DisconnectCommand : ICommand, ICommandRelatedToChangingFullPath
{
    public string? Fullpath { get; }
    public void Execute()
    {
    }
}