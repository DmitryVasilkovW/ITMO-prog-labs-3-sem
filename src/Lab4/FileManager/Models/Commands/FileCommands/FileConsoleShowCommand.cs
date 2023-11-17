using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileConsoleShowCommand : ICommand, IDependsOnFullPath
{
    private string _pathforFile;
    private string? _fullpath;
    public FileConsoleShowCommand(string pathforFile)
    {
        _pathforFile = pathforFile;
    }

    public void UpdateFullpath(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute()
    {
        string content = File.ReadAllText(_pathforFile);
        if (_fullpath is not null) _pathforFile = Path.Combine(_fullpath, _pathforFile);

        string newContent = string.Empty;
        foreach (char chackerchar in content)
        {
            if (char.IsLetterOrDigit(chackerchar) || char.IsWhiteSpace(chackerchar))
            {
                newContent += chackerchar;
            }
        }

        Console.WriteLine(newContent);
    }
}