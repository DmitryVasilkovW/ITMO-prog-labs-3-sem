using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;

public class HardDrive : IHardDrive, IPart, ICloneable
{
    public HardDrive(string? name, int capacity, int spindleRotationSpeed, int powerConsumption)
    {
        Name = name;
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; private set; }
    public int Capacity { get; private set; }
    public int SpindleRotationSpeed { get; private set; }
    public int PowerConsumption { get; private set; }
    public object Clone()
    {
        if (Name is not null)
        {
            return new HardDrive(
                (string)Name.Clone(),
                Capacity,
                SpindleRotationSpeed,
                PowerConsumption);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public HardDrive SetName(string? newName)
    {
        var clone = (HardDrive)Clone();

        clone.Name = newName;

        return clone;
    }

    public HardDrive SetCapacity(int newCapacity)
    {
        var clone = (HardDrive)Clone();

        clone.Capacity = newCapacity;

        return clone;
    }

    public HardDrive SetSpindleRotationSpeed(int newSpindleRotationSpeed)
    {
        var clone = (HardDrive)Clone();

        clone.SpindleRotationSpeed = newSpindleRotationSpeed;

        return clone;
    }

    public HardDrive SetPowerConsumption(int newPowerConsumption)
    {
        var clone = (HardDrive)Clone();

        clone.PowerConsumption = newPowerConsumption;

        return clone;
    }
}