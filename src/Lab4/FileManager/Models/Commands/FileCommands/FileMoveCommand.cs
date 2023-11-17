using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileMoveCommand : ICommand, IDependsOnFullPath
{
    private string _pathforFile;
    private string _pathforDirectory;
    private string? _fullpath;

    public FileMoveCommand(string pathforFile, string pathforDirectory)
    {
        _pathforFile = pathforFile;
        _pathforDirectory = pathforDirectory;
    }

    public void UpdateFullpath(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute()
    {
        if (_fullpath is not null) _pathforFile = Path.Combine(_fullpath, _pathforFile);
        string fileName = Path.GetFileNameWithoutExtension(_pathforFile);
        string extension = Path.GetExtension(_pathforFile);

        _pathforDirectory += '/' + fileName + extension;

        File.Move(_pathforFile, _pathforDirectory, true);
    }
}