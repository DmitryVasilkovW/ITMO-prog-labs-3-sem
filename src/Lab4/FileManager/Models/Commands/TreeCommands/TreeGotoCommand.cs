namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeGotoCommand : ICommand
{
    private string? _fullpath;

    public TreeGotoCommand(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute(ref string? path)
    {
        path = _fullpath;
    }
}