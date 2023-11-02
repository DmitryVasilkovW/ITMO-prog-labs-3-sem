using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;

public class User : IUser, IAddressee
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;

    public User(string name)
    {
        Name = name;
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
        Messagestatuses = new List<IList<Message>>();
        Messagestatuses.Add(new List<Message>());
        Messagestatuses.Add(new List<Message>());
        Messagestatuses.Add(new List<Message>());
    }

    public IList<IList<Message>> Messagestatuses { get; }

    public string Name { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        if (filter != message.ImportanceLevels)
        {
            _messages.Enqueue(message, message.ImportanceLevels);
            Messagestatuses[(int)MessageStatus.Unread].Add(message);
        }
    }

    public void SendMessage(IUser user, Message message, LevelsOfImportance filter)
    {
        user.GetMessage(message, filter);
    }
}