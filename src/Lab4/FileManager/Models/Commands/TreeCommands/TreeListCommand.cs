using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeListCommand : ICommand, IDependsOnFullPath
{
    private int _depth = 1;
    private string? _fullpath;

    public void UpdateDepth(int depth)
    {
        _depth = depth;
    }

    public void UpdateFullpath(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute()
    {
        if (_fullpath is not null) TreeList(_fullpath, _depth);
    }

    private void TreeList(string path, int depth)
    {
        if (_depth < 0)
        {
            return;
        }

        string[] files = Directory.GetFiles(path);

        Console.WriteLine("Files:");
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }

        string[] subDirs = Directory.GetDirectories(path);

        Console.WriteLine("\nSubcategories:");
        foreach (string dir in subDirs)
        {
            Console.WriteLine(dir);
            TreeList(dir, depth - 1);
        }
    }
}