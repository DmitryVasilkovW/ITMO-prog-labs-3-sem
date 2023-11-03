using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.IHaveName;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeGroup : IAddressee
{
    private IList<IName> _addressees;
    private IMYLogger _logger;

    public AddresseeGroup(string name)
    {
        Name = name;
        _addressees = new List<IName>();
        _logger = new Logger();
    }

    public string Name { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        if (filter <= message.ImportanceLevels)
        {
            foreach (IName addressee in _addressees)
            {
                ((IAddressee)addressee).GetMessage(message, filter);
                _logger.Log(message, addressee);
            }
        }
        else
        {
            foreach (IName addressee in _addressees)
            {
                _logger.Log(message, addressee);
            }
        }
    }
}