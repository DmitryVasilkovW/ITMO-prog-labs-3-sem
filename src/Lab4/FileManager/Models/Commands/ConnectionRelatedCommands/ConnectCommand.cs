namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public class ConnectCommand : ICommand
{
    private string _fullpath;

    public ConnectCommand(string fullpath)
    {
        _fullpath = fullpath;
    }

    public void Execute()
    {
    }
}