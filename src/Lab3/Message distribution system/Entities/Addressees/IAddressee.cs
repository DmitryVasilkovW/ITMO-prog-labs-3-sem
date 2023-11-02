using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public interface IAddressee
{
    string Name { get; }
    void GetMessage(Message message, LevelsOfImportance filter);
}