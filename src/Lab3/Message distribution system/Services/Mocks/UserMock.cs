using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services.Mocks;

public class UserMock : IAddressee
{
    private PriorityQueue<Message, LevelsOfImportance> _messages;
    private Message? _testmessage;

    public UserMock()
    {
        _messages = new PriorityQueue<Message, LevelsOfImportance>();
        Messagestatuses = new List<IList<Message>>();
        Messagestatuses.Add(new List<Message>());
        Messagestatuses.Add(new List<Message>());
        Messagestatuses.Add(new List<Message>());
    }

    public IList<IList<Message>> Messagestatuses { get; }
    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        if (filter != message.ImportanceLevels)
        {
            _messages.Enqueue(message, message.ImportanceLevels);
            _testmessage = message;
            Messagestatuses[(int)MessageStatus.Unread].Add(message);
        }
    }

    public MessageSendingResult Checkresultofsending()
    {
        for (int i = 0; i < _messages.Count; i++)
        {
            Message message = _messages.Dequeue();

            if (_testmessage is not null && message.Equals(_testmessage))
            {
                return MessageSendingResult.Messagegotthrough;
            }
        }

        return MessageSendingResult.Messagedidntgetthrough;
    }
}