namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeGotoCommand : ICommand
{
    private string? _fullpath;
    private ICommandStrategy _strategy;

    public TreeGotoCommand(string fullpath, ICommandStrategy strategy)
    {
        _fullpath = fullpath;
        _strategy = strategy;
    }

    public void Execute(ref string? path)
    {
        _strategy.TreeGotoCommand(_fullpath, ref path);
    }
}