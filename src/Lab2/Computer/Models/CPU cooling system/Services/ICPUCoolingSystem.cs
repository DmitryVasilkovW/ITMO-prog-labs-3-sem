using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;

public interface ICPUCoolingSystem
{
    int Dimensions { get; init; }
    IList<ISocket>? SupportedSockets { get; init; }
    int MaximumHeatDissipation { get; init; }
}