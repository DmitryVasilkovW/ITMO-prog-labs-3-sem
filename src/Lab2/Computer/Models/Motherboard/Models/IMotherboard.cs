using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;

public interface IMotherboard
{
    ISocket? CPUSocket { get; init; }
    int NumberOfPCIELanesSolderedOnTheBoard { get; init; }
    int NumberOfSATAPortsSolderedOnTheBoard { get; init; }
    int Chipset { get; init; }
    IMemoryStandard? MemoryStandard { get; init; }
    int NumberOfTablesUnderRAM { get; init; }
    IFormFactor? FormFactor { get; init; }
    Bios? Bios { get; init; }
}