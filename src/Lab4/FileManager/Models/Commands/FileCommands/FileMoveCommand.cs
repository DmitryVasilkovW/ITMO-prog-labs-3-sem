namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileMoveCommand : ICommand
{
    private string _pathforFile;
    private string _pathforDirectory;
    private ICommandStrategy _strategy;

    public FileMoveCommand(string pathforFile, string pathforDirectory, ICommandStrategy strategy)
    {
        _pathforFile = pathforFile;
        _pathforDirectory = pathforDirectory;
        _strategy = strategy;
    }

    public void Execute(ref string? path)
    {
        _strategy.FileMoveCommand(_pathforFile, _pathforDirectory, ref path);
    }
}