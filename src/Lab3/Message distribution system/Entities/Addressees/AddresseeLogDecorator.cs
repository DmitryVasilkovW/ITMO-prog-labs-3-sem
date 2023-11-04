using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeLogDecorator : IAddressee
{
    private ILogger _logger;
    private IAddressee _addressee;

    public AddresseeLogDecorator(ILogger logger, IAddressee addressee)
    {
        _logger = logger;
        _addressee = addressee;
    }

    public void GetMessage(Message message)
    {
        _logger.Log(message, _addressee);
        _addressee.GetMessage(message);
    }
}