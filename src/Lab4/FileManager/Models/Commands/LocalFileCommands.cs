using System;
using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class LocalFileCommands : ICommandStrategy
{
    public void ConnectCommand(string? fullpath, ref string? path)
    {
        path = fullpath;
    }

    public void Disconnect(ref string? path)
    {
        path = null;
    }

    public void FileConsoleShowCommand(string pathforFile, ref string? path)
    {
        string fullpath = pathforFile;
        if (path is not null) fullpath = Path.Combine(path, pathforFile);
        string content = File.ReadAllText(fullpath);

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

    public void FileCopyCommand(string pathforFile, string pathforDirectory, ref string? path)
    {
        if (path is not null) pathforFile = Path.Combine(path, pathforFile);
        string fileName = Path.GetFileNameWithoutExtension(pathforFile);
        string extension = Path.GetExtension(pathforFile);

        string newder = pathforDirectory + '/' + fileName + "-copy" + extension;

        int num = 1;

        while (File.Exists(newder))
        {
            var builder = new StringBuilder();
            builder.
                Append(pathforDirectory).
                Append('/').
                Append(fileName).
                Append("-copy").
                Append(num).
                Append(extension);

            newder = builder.ToString();

            num++;
        }

        File.Copy(pathforFile, newder);
    }

    public void FileDeleteCommand(string pathforFile, ref string? path)
    {
        if (path is not null) pathforFile = Path.Combine(path, pathforFile);
        File.Delete(pathforFile);
    }

    public void FileMoveCommand(string pathforFile, string pathforDirectory, ref string? path)
    {
        if (path is not null) pathforFile = Path.Combine(path, pathforFile);
        string fileName = Path.GetFileNameWithoutExtension(pathforFile);
        string extension = Path.GetExtension(pathforFile);

        pathforDirectory += '/' + fileName + extension;

        File.Move(pathforFile, pathforDirectory, true);
    }

    public void FileRenameCommand(string pathforFile, string newname, ref string? path)
    {
        if (path is not null) pathforFile = Path.Combine(path, pathforFile);
        string newder = pathforFile.Replace(Path.GetFileNameWithoutExtension(pathforFile), newname, StringComparison.Ordinal);

        int num = 1;
        while (File.Exists(newder))
        {
            newder = pathforFile.Replace(Path.GetFileNameWithoutExtension(pathforFile), newname + num, StringComparison.Ordinal);

            num++;
        }

        File.Move(pathforFile, newder);
    }

    public void TreeGotoCommand(string? fullpath, ref string? path)
    {
        path = fullpath;
    }

    public void TreeListCommand(int depth, ICanPrint print, ref string? path)
    {
        if (path is not null) TreeList(path, depth, print);
    }

    private void TreeList(string path, int depth, ICanPrint print)
    {
        if (depth < 0)
        {
            return;
        }

        string[] files = Directory.GetFiles(path);

        Console.WriteLine("Files:");
        foreach (string file in files)
        {
            print.Print(file);
        }

        string[] subDirs = Directory.GetDirectories(path);

        Console.WriteLine("\nSubcategories:");
        foreach (string dir in subDirs)
        {
            Console.WriteLine(dir);
            TreeList(dir, depth - 1, print);
        }
    }
}