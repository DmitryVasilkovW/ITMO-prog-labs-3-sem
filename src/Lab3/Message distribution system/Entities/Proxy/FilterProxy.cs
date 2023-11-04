using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Proxy;

public class FilterProxy : IAddressee
{
    private IAddressee _addressee;

    public FilterProxy(IAddressee addressee)
    {
        _addressee = addressee;
    }

    public void GetMessage(Message message)
    {
        if (((IHavefilter)_addressee).Filter <= message.ImportanceLevels)
            _addressee.GetMessage(message);
    }
}