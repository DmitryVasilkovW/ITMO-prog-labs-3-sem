using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMP;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class RAMFactory : IPartFactory<Ram, TableOfRAMCharacteristics>
{
    public Ram CreatePart(TableOfRAMCharacteristics characteristics)
    {
        int numberOfAvailableMemorySize = characteristics.NumberOfAvailableMemorySize;
        int supportedFrequencies = characteristics.SupportedFrequencies;
        IXMP? xmp = characteristics.Xmp;
        IFormFactor? formFactor = characteristics.FormFactor;
        IConnectionOption? connectionOption = characteristics.ConnectionOption;
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