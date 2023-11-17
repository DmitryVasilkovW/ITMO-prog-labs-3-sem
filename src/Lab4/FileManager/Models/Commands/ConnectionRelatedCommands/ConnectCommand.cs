namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class ConnectCommand : ICommand, ICommandRelatedToChangingFullPath
{
    public ConnectCommand(string fullpath)
    {
        Fullpath = fullpath;
    }

    public string Fullpath { get; }

    public void Execute()
    {
    }
}