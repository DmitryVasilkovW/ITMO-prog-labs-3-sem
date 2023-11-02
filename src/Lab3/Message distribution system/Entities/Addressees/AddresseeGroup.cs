using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messagedistributionsystem.Entities.Addressees;

public class AddresseeGroup : IAddressee
{
    private IList<IAddressee> _addressees;

    public AddresseeGroup(string name)
    {
        Name = name;
        _addressees = new List<IAddressee>();
    }

    public string Name { get; }

    public void GetMessage(Message message, LevelsOfImportance filter)
    {
        if (filter != message.ImportanceLevels)
        {
            foreach (IAddressee addressee in _addressees)
            {
                addressee.GetMessage(message, filter);
            }
        }
    }
}