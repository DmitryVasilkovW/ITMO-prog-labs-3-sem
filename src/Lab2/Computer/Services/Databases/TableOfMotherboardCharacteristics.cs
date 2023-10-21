using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfMotherboardCharacteristics : IPartCharacteristics, IMotherboard
{
    public TableOfMotherboardCharacteristics(
        string name,
        ISocket socket,
        int numberOfPcieLanesSolderedOnTheBoard,
        int numberOfSataPortsSolderedOnTheBoard,
        IList<int> chipsets,
        IMemoryStandard memoryStandard,
        int numberOfTablesUnderRam,
        IFormFactor formFactor,
        Bios bios)
    {
        Name = name;
        CPUSocket = socket;
        NumberOfPCIELanesSolderedOnTheBoard = numberOfPcieLanesSolderedOnTheBoard;
        NumberOfSATAPortsSolderedOnTheBoard = numberOfSataPortsSolderedOnTheBoard;
        Chipset = chipsets;
        MemoryStandard = memoryStandard;
        NumberOfTablesUnderRAM = numberOfTablesUnderRam;
        FormFactor = formFactor;
        Bios = bios;
    }

    public string? Name { get; init; }
    public ISocket? CPUSocket { get; init; }
    public int NumberOfPCIELanesSolderedOnTheBoard { get; init; }
    public int NumberOfSATAPortsSolderedOnTheBoard { get; init; }
    public IList<int>? Chipset { get; init; }
    public IMemoryStandard? MemoryStandard { get; init; }
    public int NumberOfTablesUnderRAM { get; init; }
    public IFormFactor? FormFactor { get; init; }
    public Bios? Bios { get; init; }
}