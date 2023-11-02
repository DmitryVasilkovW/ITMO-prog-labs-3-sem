using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Messengers;

public class Messenger
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;

    public Messenger()
    {
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
    }

    public void GetMessage(Message message)
    {
        _messages.Enqueue(message, message.ImportanceLevels);
    }
}