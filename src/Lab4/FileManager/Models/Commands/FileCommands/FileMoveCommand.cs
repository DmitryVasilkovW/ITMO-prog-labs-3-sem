using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileMoveCommand : ICommand
{
    private string _pathforFile;
    private string _pathforDirectory;

    public FileMoveCommand(string pathforFile, string pathforDirectory)
    {
        _pathforFile = pathforFile;
        _pathforDirectory = pathforDirectory;
    }

    public void Execute(ref string? path)
    {
        if (path is not null) _pathforFile = Path.Combine(path, _pathforFile);
        string fileName = Path.GetFileNameWithoutExtension(_pathforFile);
        string extension = Path.GetExtension(_pathforFile);

        _pathforDirectory += '/' + fileName + extension;

        File.Move(_pathforFile, _pathforDirectory, true);
    }
}