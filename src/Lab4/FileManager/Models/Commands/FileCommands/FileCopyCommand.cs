using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileCopyCommand : ICommand, IDependsOnFullPath
{
    private string _pathforFile;
    private string _pathforDirectory;
    private string? _fullpath;

    public FileCopyCommand(string pathforFile, string pathforDirectory)
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

        string newder = _pathforDirectory + '/' + fileName + "-copy" + extension;

        int num = 1;

        while (File.Exists(newder))
        {
            var builder = new StringBuilder();
            builder.
                Append(_pathforDirectory).
                Append('/').
                Append(fileName).
                Append("-copy").
                Append(num).
                Append(extension);

            newder = builder.ToString();

            num++;
        }

        File.Copy(_pathforFile, newder);
    }
}