using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    private string _pathforFile;

    public FileDeleteCommand(string pathforFile)
    {
        _pathforFile = pathforFile;
    }

    public void Execute()
    {
        File.Delete(_pathforFile);
    }
}