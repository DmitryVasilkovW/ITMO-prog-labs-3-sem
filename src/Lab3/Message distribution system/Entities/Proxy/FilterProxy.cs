using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Proxy;

public class FilterProxy : IAddressee
{
    private IAddressee _addressee;
    private LevelsOfImportance _filter;

    public FilterProxy(IAddressee addressee, LevelsOfImportance filter)
    {
        _addressee = addressee;
        _filter = filter;
    }

    public void GetMessage(Message message)
    {
        if (_filter <= message.ImportanceLevels)
            _addressee.GetMessage(message);
    }
}