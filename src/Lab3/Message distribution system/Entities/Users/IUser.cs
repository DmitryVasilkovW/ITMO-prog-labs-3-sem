using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;

public interface IUser
{
    void GetMessage(Message message, LevelsOfImportance filter);
    void SendMessage(IUser user, Message message, LevelsOfImportance filter);
}