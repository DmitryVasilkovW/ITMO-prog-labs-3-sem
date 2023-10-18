using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfMotherboardCharacteristics : IPartCharacteristics, IMotherboard
{
    public string? Name { get; init; }
    public ISocket? CPUSocket { get; init; }
    public int NumberOfPCIELanesSolderedOnTheBoard { get; init; }
    public int NumberOfSATAPortsSolderedOnTheBoard { get; init; }
    public int Chipset { get; init; }
    public IMemoryStandard? MemoryStandard { get; init; }
    public int NumberOfTablesUnderRAM { get; init; }
    public IFormFactor? FormFactor { get; init; }
    public Bios? Bios { get; init; }
}