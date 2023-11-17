namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeGotoCommand : ICommand
{
    public TreeGotoCommand(string fullpath)
    {
        Fullpath = fullpath;
    }

    public string Fullpath { get; }

    public void Execute(ref string? path)
    {
        path = Fullpath;
    }
}