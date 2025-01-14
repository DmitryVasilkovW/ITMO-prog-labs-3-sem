using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfCPUCoolingSystemCharacteristics : ICPUCoolingSystem, IPartCharacteristics
{
    public TableOfCPUCoolingSystemCharacteristics(
        Dimensions dimensions,
        IList<ISocket> sockets,
        int maximumHeatDissipation,
        string name)
    {
        Dimensions = dimensions;
        SupportedSockets = sockets;
        MaximumHeatDissipation = maximumHeatDissipation;
        Name = name;
    }

    public Dimensions Dimensions { get; }
    public IList<ISocket>? SupportedSockets { get; }
    public int MaximumHeatDissipation { get; }
    public string? Name { get; }
}