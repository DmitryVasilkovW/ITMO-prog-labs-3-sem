using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Topics;

public class Topic : ITopic
{
    private string _title;
    private IList<Message> _messages;

    public Topic(string title)
    {
        _title = title;
        _messages = new List<Message>();
    }

    public void Send(IAddressee addressee, Message message, LevelsOfImportance filter)
    {
        if (filter != message.ImportanceLevels)
        {
            _messages.Add(message);
            addressee.GetMessage(message, filter);
        }
    }
}