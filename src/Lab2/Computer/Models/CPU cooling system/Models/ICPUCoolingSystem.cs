using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Services;

public interface ICPUCoolingSystem
{
    int Dimensions { get; }
    IList<ISocket>? SupportedSockets { get; }
    int MaximumHeatDissipation { get; }
}