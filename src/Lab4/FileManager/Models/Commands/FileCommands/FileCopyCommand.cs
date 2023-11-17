using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.FileCommands;

public class FileCopyCommand : ICommand
{
    private string _pathforFile;
    private string _pathforDirectory;

    public FileCopyCommand(string pathforFile, string pathforDirectory)
    {
        _pathforFile = pathforFile;
        _pathforDirectory = pathforDirectory;
    }

    public void Execute(ref string? path)
    {
        if (path is not null) _pathforFile = Path.Combine(path, _pathforFile);
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