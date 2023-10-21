using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class MotherboardFactory : IPartFactory<Motherboard, TableOfMotherboardCharacteristics>
{
    public Motherboard CreatePart(TableOfMotherboardCharacteristics characteristics)
    {
        return new Motherboard(
            characteristics.CPUSocket,
            characteristics.NumberOfPCIELanesSolderedOnTheBoard,
            characteristics.NumberOfSATAPortsSolderedOnTheBoard,
            characteristics.Chipset,
            characteristics.MemoryStandard,
            characteristics.NumberOfTablesUnderRAM,
            characteristics.FormFactor,
            characteristics.Bios,
            characteristics.Name);
    }
}