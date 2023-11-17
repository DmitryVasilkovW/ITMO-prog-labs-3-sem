using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileDeleteCommand : ICommand, IDependsOnFullPath
{
    private string _pathforFile;
    private string? _fullpath;

    public FileDeleteCommand(string pathforFile)
    {
        _pathforFile = pathforFile;
    }

    public void UpdateFullpath(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute()
    {
        if (_fullpath is not null) _pathforFile = Path.Combine(_fullpath, _pathforFile);
        File.Delete(_pathforFile);
    }
}