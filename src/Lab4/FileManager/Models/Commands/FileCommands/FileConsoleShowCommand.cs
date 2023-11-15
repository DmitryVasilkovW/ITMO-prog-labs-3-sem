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

    public void Execute()
    {
        string content = File.ReadAllText(_pathforFile);

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