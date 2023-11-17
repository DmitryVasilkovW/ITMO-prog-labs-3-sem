using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileRenameCommand : ICommand, IDependsOnFullPath
{
    private string _pathforFile;
    private string _newname;
    private string? _fullpath;

    public FileRenameCommand(string pathforFile, string newname)
    {
        _pathforFile = pathforFile;
        _newname = newname;
    }

    public void UpdateFullpath(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute()
    {
        if (_fullpath is not null) _pathforFile = Path.Combine(_fullpath, _pathforFile);
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