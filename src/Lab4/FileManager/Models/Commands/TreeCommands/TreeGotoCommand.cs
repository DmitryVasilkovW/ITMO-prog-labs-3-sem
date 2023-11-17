namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeGotoCommand : ICommand, ICommandRelatedToChangingFullPath
{
    public TreeGotoCommand(string fullpath)
    {
        Fullpath = fullpath;
    }

    public string Fullpath { get; }

    public void Execute()
    {
    }
}