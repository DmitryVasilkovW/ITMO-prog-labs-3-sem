using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class CPUCoolingSystemFactory : IPartFactory<CPUCoolingSystem, TableOfCPUCoolingSystemCharacteristics>
{
    public CPUCoolingSystem CreatePart(TableOfCPUCoolingSystemCharacteristics characteristics)
    {
        string? name = characteristics.Name;
        int dimensions = characteristics.Dimensions;
        IList<ISocket>? supportedSockets = characteristics.SupportedSockets;
        int maximumHeatDissipation = characteristics.MaximumHeatDissipation;

        return new CPUCoolingSystem(name, dimensions, supportedSockets, maximumHeatDissipation);
    }
}