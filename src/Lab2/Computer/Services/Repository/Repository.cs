using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Repository;

public class Repository
{
    private Database _database = new Database();

    public void AddNewPart(int id, IPartCharacteristics newtable)
    {
        _database.Addtable(id, newtable);
    }

    public IPart GetPart(string name)
    {
        IPartCharacteristics characteristics = _database.FindByName(name);

        switch (characteristics)
        {
            case TableOfCPUCharacteristics:
                Processor cpu = new CPUFactory().CreatePart((TableOfCPUCharacteristics)characteristics);
                return cpu;
        }

        throw new AggregateException();
    }
}