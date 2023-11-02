using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public interface IAddressee
{
    void GetMessage(Message message, LevelsOfImportance filter);
}