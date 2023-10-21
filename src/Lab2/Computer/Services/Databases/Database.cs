using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

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

            case ICorpus:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case ICPUCoolingSystem:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case IHardDrive:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case IMotherboard:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case IPowerSupply:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case IRAM:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case ISSDDrive:
                _tables.Add(new PartsTable(id, newtable));
                break;

            case IVideoCard:
                _tables.Add(new PartsTable(id, newtable));
                break;

            default:
                throw new ThePassedArgumentIsNullException();
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

        throw new ThePassedArgumentIsNullException();
    }
}