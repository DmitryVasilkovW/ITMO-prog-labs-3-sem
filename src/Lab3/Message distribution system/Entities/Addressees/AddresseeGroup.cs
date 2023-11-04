using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeGroup : IAddressee
{
    private IList<IAddressee> _addressees;
    private IConsoleLogger _logger;

    public AddresseeGroup(string name, IConsoleLogger logger)
    {
        Name = name;
        _addressees = new List<IAddressee>();
        _logger = logger;
    }

    public string Name { get; }

    public void GetMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.GetMessage(message);
            _logger.Log(message, addressee);
        }
    }
}