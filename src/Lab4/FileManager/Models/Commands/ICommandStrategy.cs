namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Models.Commands;

public interface ICommandStrategy
{
    void ConnectCommand(string? fullpath, ref string? path);
    void Disconnect(ref string? path);
    void FileConsoleShowCommand(string pathforFile, ref string? path);

    void FileCopyCommand(string pathforFile, string pathforDirectory, ref string? path);
    void FileDeleteCommand(string pathforFile, ref string? path);
    void FileMoveCommand(string pathforFile, string pathforDirectory, ref string? path);
    void FileRenameCommand(string pathforFile, string newname, ref string? path);
    void TreeGotoCommand(string? fullpath, ref string? path);
    void TreeListCommand(int depth, ICanPrint print, ref string? path);
}