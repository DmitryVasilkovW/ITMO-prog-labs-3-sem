using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeGroupLogDecorator : IAddressee
{
    private IList<IAddressee> _addressees = new List<IAddressee>();
    private ILogger _logger;

    public AddresseeGroupLogDecorator(ILogger logger)
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