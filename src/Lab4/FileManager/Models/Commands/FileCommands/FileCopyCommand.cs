namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileCopyCommand : ICommand
{
    private string _pathforFile;
    private string _pathforDirectory;
    private ICommandStrategy _strategy;

    public FileCopyCommand(string pathforFile, string pathforDirectory, ICommandStrategy strategy)
    {
        _pathforFile = pathforFile;
        _pathforDirectory = pathforDirectory;
        _strategy = strategy;
    }

    public void Execute(ref string? path)
    {
        _strategy.FileCopyCommand(_pathforFile, _pathforDirectory, ref path);
    }
}