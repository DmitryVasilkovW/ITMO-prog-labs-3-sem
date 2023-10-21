using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;

public class CPUCoolingSystem : ICPUCoolingSystem, IPart, ICloneable
{
    public CPUCoolingSystem(string? name, Dimensions dimensions, IList<ISocket>? supportedSockets, int maximumHeatDissipation)
    {
        Name = name;
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaximumHeatDissipation = maximumHeatDissipation;
    }

    public string? Name { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public IList<ISocket>? SupportedSockets { get; private set; }
    public int MaximumHeatDissipation { get; private set; }
    public object Clone()
    {
        if (Name is not null && Dimensions is not null)
        {
            return new CPUCoolingSystem(
                (string)Name.Clone(),
                Dimensions,
                SupportedSockets,
                MaximumHeatDissipation);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public CPUCoolingSystem SetName(string? newName)
    {
        var clone = (CPUCoolingSystem)Clone();

        clone.Name = newName;

        return clone;
    }

    public CPUCoolingSystem SetDimensions(Dimensions newDimensions)
    {
        var clone = (CPUCoolingSystem)Clone();

        clone.Dimensions = newDimensions;

        return clone;
    }

    public CPUCoolingSystem SetSupportedSockets(IList<ISocket> newSupportedSockets)
    {
        var clone = (CPUCoolingSystem)Clone();

        clone.SupportedSockets = newSupportedSockets;

        return clone;
    }

    public CPUCoolingSystem SetMaximumHeatDissipation(int newMaximumHeatDissipation)
    {
        var clone = (CPUCoolingSystem)Clone();

        clone.MaximumHeatDissipation = newMaximumHeatDissipation;

        return clone;
    }
}