using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;

public class SSDDrive : ISSDDrive, IPart, IPrototype<SSDDrive>
{
    public SSDDrive(string? name, IConnectionOption? connectionOption, int capacity, int maximumOperatingSpeed, int powerConsumption)
    {
        Name = name;
        ConnectionOption = connectionOption;
        Capacity = capacity;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; private set; }
    public IConnectionOption? ConnectionOption { get; private set; }
    public int Capacity { get; private set; }
    public int MaximumOperatingSpeed { get; private set; }
    public int PowerConsumption { get; private set; }
    public SSDDrive Clone()
    {
        if (Name is not null)
        {
            return new SSDDrive(
                (string)Name.Clone(),
                ConnectionOption,
                Capacity,
                MaximumOperatingSpeed,
                PowerConsumption);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public SSDDrive SetName(string? newName)
    {
        SSDDrive clone = Clone();

        clone.Name = newName;

        return clone;
    }

    public SSDDrive SetConnectionOption(IConnectionOption newConnectionOption)
    {
        SSDDrive clone = Clone();

        clone.ConnectionOption = newConnectionOption;

        return clone;
    }

    public SSDDrive SetCapacity(int newCapacity)
    {
        SSDDrive clone = Clone();

        clone.Capacity = newCapacity;

        return clone;
    }

    public SSDDrive SetMaximumOperatingSpeed(int newMaximumOperatingSpeed)
    {
        SSDDrive clone = Clone();

        clone.MaximumOperatingSpeed = newMaximumOperatingSpeed;

        return clone;
    }

    public SSDDrive SetPowerConsumption(int newPowerConsumption)
    {
        SSDDrive clone = Clone();

        clone.PowerConsumption = newPowerConsumption;

        return clone;
    }
}