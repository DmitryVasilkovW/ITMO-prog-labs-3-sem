using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class Database
{
    private IList<PartsTable> _tables = new List<PartsTable>();

    public void Addtable(int id, IPartCharacteristics newtable)
    {
        switch (newtable)
        {
            case ICPU:
                _tables.Add(new PartsTable(id, newtable));
                break;
        }
    }

    public IPartCharacteristics FindByName(string name)
    {
        foreach (PartsTable table in _tables)
        {
            if (table.PartCharacteristics.Name is not null && table.PartCharacteristics.Name.Equals(name, StringComparison.Ordinal))
            {
                return table.PartCharacteristics;
            }
        }

        // заменить на свой
        throw new InvalidCastException();
    }
}