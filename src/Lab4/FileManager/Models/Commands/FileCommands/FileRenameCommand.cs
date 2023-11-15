using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileRenameCommand : ICommand
{
    private string _pathforFile;
    private string _newname;

    public FileRenameCommand(string pathforFile, string newname)
    {
        _pathforFile = pathforFile;
        _newname = newname;
    }

    public void Execute()
    {
        string newder = _pathforFile.Replace(Path.GetFileNameWithoutExtension(_pathforFile), _newname, StringComparison.Ordinal);

        int num = 1;
        while (File.Exists(newder))
        {
            newder = _pathforFile.Replace(Path.GetFileNameWithoutExtension(_pathforFile), _newname + num, StringComparison.Ordinal);

            num++;
        }

        File.Move(_pathforFile, newder);
    }
}