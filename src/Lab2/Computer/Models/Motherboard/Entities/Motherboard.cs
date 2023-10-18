using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;

public class Motherboard : IMotherboard, IPart
{
    public Motherboard(
        ISocket? socket,
        int numberOfPcieLanesSolderedOnTheBoard,
        int numberOfSataPortsSolderedOnTheBoard,
        int chipset,
        IMemoryStandard? memoryStandard,
        int numberOfTablesUnderRam,
        IFormFactor? formFactor,
        Bios? bios,
        string? name)
    {
        CPUSocket = socket;
        NumberOfSATAPortsSolderedOnTheBoard = numberOfSataPortsSolderedOnTheBoard;
        NumberOfPCIELanesSolderedOnTheBoard = numberOfPcieLanesSolderedOnTheBoard;
        Chipset = chipset;
        MemoryStandard = memoryStandard;
        NumberOfTablesUnderRAM = numberOfTablesUnderRam;
        FormFactor = formFactor;
        Bios = bios;
        Name = name;
    }

    public ISocket? CPUSocket { get; init; }
    public int NumberOfPCIELanesSolderedOnTheBoard { get; init; }
    public int NumberOfSATAPortsSolderedOnTheBoard { get; init; }
    public int Chipset { get; init; }
    public IMemoryStandard? MemoryStandard { get; init; }
    public int NumberOfTablesUnderRAM { get; init; }
    public IFormFactor? FormFactor { get; init; }
    public Bios? Bios { get; init; }
    public string? Name { get; init; }
}