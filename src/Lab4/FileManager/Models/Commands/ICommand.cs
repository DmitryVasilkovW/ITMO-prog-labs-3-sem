namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public interface ICommand
{
    void Execute(ref string? path);
}