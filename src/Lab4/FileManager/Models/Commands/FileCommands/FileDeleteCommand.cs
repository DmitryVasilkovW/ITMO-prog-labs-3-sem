namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    private string _pathforFile;
    private ICommandStrategy _strategy;

    public FileDeleteCommand(string pathforFile, ICommandStrategy strategy)
    {
        _pathforFile = pathforFile;
        _strategy = strategy;
    }

    public void Execute(ref string? path)
    {
        _strategy.FileDeleteCommand(_pathforFile, ref path);
    }
}