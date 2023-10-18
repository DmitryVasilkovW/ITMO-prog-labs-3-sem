using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class MotherboardFactory : IPartFactory<Motherboard, TableOfMotherboardCharacteristics>
{
    public Motherboard CreatePart(TableOfMotherboardCharacteristics characteristics)
    {
        ISocket? cPUSocket = characteristics.CPUSocket;
        int numberOfPCIELanesSolderedOnTheBoard = characteristics.NumberOfPCIELanesSolderedOnTheBoard;
        int numberOfSATAPortsSolderedOnTheBoard = characteristics.NumberOfSATAPortsSolderedOnTheBoard;
        int chipset = characteristics.Chipset;
        IMemoryStandard? memoryStandard = characteristics.MemoryStandard;
        int numberOfTablesUnderRAM = characteristics.NumberOfTablesUnderRAM;
        IFormFactor? formFactor = characteristics.FormFactor;
        Bios? bios = characteristics.Bios;
        string? name = characteristics.Name;

        return new Motherboard(
            cPUSocket,
            numberOfPCIELanesSolderedOnTheBoard,
            numberOfSATAPortsSolderedOnTheBoard,
            chipset,
            memoryStandard,
            numberOfTablesUnderRAM,
            formFactor,
            bios,
            name);
    }
}