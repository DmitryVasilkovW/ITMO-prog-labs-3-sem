using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    private string _pathforFile;

    public FileDeleteCommand(string pathforFile)
    {
        _pathforFile = pathforFile;
    }

    public void Execute(ref string? path)
    {
        if (path is not null) _pathforFile = Path.Combine(path, _pathforFile);
        File.Delete(_pathforFile);
    }
}