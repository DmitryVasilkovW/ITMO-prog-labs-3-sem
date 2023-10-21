using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;

public class CPUCoolingSystem : ICPUCoolingSystem, IPart, IPrototype<CPUCoolingSystem>
{
    public CPUCoolingSystem(string? name, int dimensions, IList<ISocket>? supportedSockets, int maximumHeatDissipation)
    {
        Name = name;
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaximumHeatDissipation = maximumHeatDissipation;
    }

    public string? Name { get; private set; }
    public int Dimensions { get; private set; }
    public IList<ISocket>? SupportedSockets { get; private set; }
    public int MaximumHeatDissipation { get; private set; }
    public CPUCoolingSystem Clone()
    {
        if (Name is not null)
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
        CPUCoolingSystem clone = Clone();

        clone.Name = newName;

        return clone;
    }

    public CPUCoolingSystem SetDimensions(int newDimensions)
    {
        CPUCoolingSystem clone = Clone();

        clone.Dimensions = newDimensions;

        return clone;
    }

    public CPUCoolingSystem SetSupportedSockets(IList<ISocket> newSupportedSockets)
    {
        CPUCoolingSystem clone = Clone();

        clone.SupportedSockets = newSupportedSockets;

        return clone;
    }

    public CPUCoolingSystem SetMaximumHeatDissipation(int newMaximumHeatDissipation)
    {
        CPUCoolingSystem clone = Clone();

        clone.MaximumHeatDissipation = newMaximumHeatDissipation;

        return clone;
    }
}