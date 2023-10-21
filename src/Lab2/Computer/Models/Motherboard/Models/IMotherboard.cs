using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;

public interface IMotherboard
{
    ISocket? CPUSocket { get; }
    int NumberOfPCIELanesSolderedOnTheBoard { get; }
    int NumberOfSATAPortsSolderedOnTheBoard { get; }
    IList<int>? Chipset { get; }
    IMemoryStandard? MemoryStandard { get; }
    int NumberOfTablesUnderRAM { get; }
    IFormFactor? FormFactor { get; }
    Bios? Bios { get; }
}