namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileRenameCommand : ICommand
{
    private string _pathforFile;
    private string _newname;
    private ICommandStrategy _strategy;

    public FileRenameCommand(string pathforFile, string newname, ICommandStrategy strategy)
    {
        _pathforFile = pathforFile;
        _newname = newname;
        _strategy = strategy;
    }

    public void Execute(ref string? path)
    {
        _strategy.FileRenameCommand(_pathforFile, _newname, ref path);
    }
}