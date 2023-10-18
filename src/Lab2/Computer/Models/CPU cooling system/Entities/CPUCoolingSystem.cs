using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;

public class CPUCoolingSystem : ICPUCoolingSystem, IPart
{
    public CPUCoolingSystem(string? name, int dimensions, IList<ISocket>? supportedSockets, int maximumHeatDissipation)
    {
        Name = name;
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaximumHeatDissipation = maximumHeatDissipation;
    }

    public string? Name { get; init; }
    public int Dimensions { get; init; }
    public IList<ISocket>? SupportedSockets { get; init; }
    public int MaximumHeatDissipation { get; init; }
}