using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands.TreeCommands;

public class TreeListCommand : ICommand
{
    private const int Initialdepth = 1;
    private int _depth = Initialdepth;

    public void UpdateDepth(int depth)
    {
        _depth = depth;
    }

    public void Execute(ref string? path)
    {
        if (path is not null) TreeList(path, _depth);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
            return false;

        var command = (TreeListCommand)obj;
        return _depth == command._depth;
    }

    public override int GetHashCode()
    {
        return StringComparer.Ordinal.GetHashCode(_depth);
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