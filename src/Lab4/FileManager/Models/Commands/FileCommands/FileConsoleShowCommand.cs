using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileConsoleShowCommand : ICommand
{
    private string _pathforFile;
    public FileConsoleShowCommand(string pathforFile)
    {
        _pathforFile = pathforFile;
    }

    public void Execute(ref string? path)
    {
        string content = File.ReadAllText(_pathforFile);
        if (path is not null) _pathforFile = Path.Combine(path, _pathforFile);

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