using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class RAMFactory : IPartFactory<Ram, TableOfRAMCharacteristics>
{
    public Ram CreatePart(TableOfRAMCharacteristics characteristics)
    {
        int numberOfAvailableMemorySize = characteristics.NumberOfAvailableMemorySize;
        int supportedFrequencies = characteristics.SupportedFrequencies;
        XMP? xmp = characteristics.Xmp;
        IFormFactor? formFactor = characteristics.FormFactor;
        IMemoryStandard? connectionOption = characteristics.ConnectionOption;
        int powerConsumption = characteristics.PowerConsumption;
        string? name = characteristics.Name;

        return new Ram(
            numberOfAvailableMemorySize,
            supportedFrequencies,
            xmp,
            formFactor,
            connectionOption,
            powerConsumption,
            name);
    }
}