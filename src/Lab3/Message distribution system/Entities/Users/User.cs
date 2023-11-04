using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;

public class User : IUser, IAddressee, IName
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;
    private LevelsOfImportance _filter;

    public User(string name, LevelsOfImportance filter)
    {
        Name = name;
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
        Messagestatuses = new List<IList<Message>>();
        Messagestatuses.Add(new List<Message>());
        Messagestatuses.Add(new List<Message>());
        Messagestatuses.Add(new List<Message>());
        _filter = filter;
    }

    public IList<IList<Message>> Messagestatuses { get; }

    public string Name { get; }

    public void GetMessage(Message message)
    {
        if (_filter <= message.ImportanceLevels)
        {
            _messages.Enqueue(message, message.ImportanceLevels);
            Messagestatuses[(int)MessageStatus.Unread].Add(message);
        }
    }

    public MessageStatusChangeResults MarkMessageAsRead(Message messageForSetStatus)
    {
        for (int i = 0; i < Messagestatuses[(int)MessageStatus.Unread].Count; i++)
        {
            if (Messagestatuses[(int)MessageStatus.Unread][i].Equals(messageForSetStatus))
            {
                Messagestatuses[(int)MessageStatus.Unread].RemoveAt(i);
                Messagestatuses[(int)MessageStatus.Read].Add(messageForSetStatus);
                return MessageStatusChangeResults.ChangeOfStatusWasSuccessful;
            }
        }

        return MessageStatusChangeResults.CannotChangeMessageStatus;
    }

    public void SendMessage(IUser user, Message message)
    {
        ((IAddressee)user).GetMessage(message);
    }
}