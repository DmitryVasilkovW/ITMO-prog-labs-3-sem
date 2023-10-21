using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;

public class Motherboard : IMotherboard, IPart, IPrototype<Motherboard>
{
    public Motherboard(
        ISocket? socket,
        int numberOfPcieLanesSolderedOnTheBoard,
        int numberOfSataPortsSolderedOnTheBoard,
        IList<int>? chipset,
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

    public ISocket? CPUSocket { get; private set; }
    public int NumberOfPCIELanesSolderedOnTheBoard { get; private set; }
    public int NumberOfSATAPortsSolderedOnTheBoard { get; private set; }
    public IList<int>? Chipset { get; private set; }
    public IMemoryStandard? MemoryStandard { get; private set; }
    public int NumberOfTablesUnderRAM { get; private set; }
    public IFormFactor? FormFactor { get; private set; }
    public Bios? Bios { get; private set; }
    public string? Name { get; private set; }
    public Motherboard Clone()
    {
        if (Name is not null && Bios is not null)
        {
            return new Motherboard(
                CPUSocket,
                NumberOfSATAPortsSolderedOnTheBoard,
                NumberOfPCIELanesSolderedOnTheBoard,
                Chipset,
                MemoryStandard,
                NumberOfTablesUnderRAM,
                FormFactor,
                Bios.Clone(),
                (string)Name.Clone());
        }

        throw new ThePassedArgumentIsNullException();
    }

    public Motherboard SetName(string? newName)
    {
        Motherboard clone = Clone();

        clone.Name = newName;

        return clone;
    }

    public Motherboard SetNumberOfPCIELanesSolderedOnTheBoard(int newNumberOfPCIELanesSolderedOnTheBoard)
    {
        Motherboard clone = Clone();

        clone.NumberOfPCIELanesSolderedOnTheBoard = newNumberOfPCIELanesSolderedOnTheBoard;

        return clone;
    }

    public Motherboard SetCPUSocket(ISocket newCPUSocket)
    {
        Motherboard clone = Clone();

        clone.CPUSocket = newCPUSocket;

        return clone;
    }

    public Motherboard SetNumberOfSATAPortsSolderedOnTheBoard(int newNumberOfSATAPortsSolderedOnTheBoard)
    {
        Motherboard clone = Clone();

        clone.NumberOfSATAPortsSolderedOnTheBoard = newNumberOfSATAPortsSolderedOnTheBoard;

        return clone;
    }

    public Motherboard SetChipset(IList<int>? newChipset)
    {
        Motherboard clone = Clone();

        clone.Chipset = newChipset;

        return clone;
    }

    public Motherboard SetMemoryStandard(IMemoryStandard newMemoryStandard)
    {
        Motherboard clone = Clone();

        clone.MemoryStandard = newMemoryStandard;

        return clone;
    }

    public Motherboard SetNumberOfTablesUnderRAM(int newNumberOfTablesUnderRAM)
    {
        Motherboard clone = Clone();

        clone.NumberOfTablesUnderRAM = newNumberOfTablesUnderRAM;

        return clone;
    }

    public Motherboard SetFormFactor(IFormFactor newFormFactor)
    {
        Motherboard clone = Clone();

        clone.FormFactor = newFormFactor;

        return clone;
    }

    public Motherboard SetBios(Bios newBios)
    {
        Motherboard clone = Clone();

        clone.Bios = newBios;

        return clone;
    }
}