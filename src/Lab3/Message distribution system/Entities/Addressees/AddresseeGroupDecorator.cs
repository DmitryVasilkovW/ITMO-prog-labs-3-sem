using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeGroupDecorator : IAddressee
{
    private IList<IAddressee> _addressees = new List<IAddressee>();
    private IConsoleLogger _logger;

    public AddresseeGroupDecorator(IConsoleLogger logger)
    {
        _logger = logger;
    }

    public void GetMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.GetMessage(message);
            _logger.Log(message, addressee);
        }
    }
}