using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeDecorator : IAddressee
{
    private IConsoleLogger _logger;
    private IAddressee _addressee;

    public AddresseeDecorator(IConsoleLogger logger, IAddressee addressee)
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