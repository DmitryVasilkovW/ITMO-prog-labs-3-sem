using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfCPUCoolingSystemCharacteristics : ICPUCoolingSystem, IPartCharacteristics
{
    public int Dimensions { get; init; }
    public IList<ISocket>? SupportedSockets { get; init; }
    public int MaximumHeatDissipation { get; init; }
    public string? Name { get; init; }
}