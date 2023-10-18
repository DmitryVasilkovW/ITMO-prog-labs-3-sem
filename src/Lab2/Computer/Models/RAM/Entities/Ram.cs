using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;

public class Ram : IRAM, IPart
{
    public Ram(
        int numberOfAvailableMemorySize,
        int supportedFrequencies,
        IXMP? xmp,
        IFormFactor? formFactor,
        IConnectionOption? connectionOption,
        int powerConsumption,
        string? name)
    {
        NumberOfAvailableMemorySize = numberOfAvailableMemorySize;
        SupportedFrequencies = supportedFrequencies;
        Xmp = xmp;
        FormFactor = formFactor;
        ConnectionOption = connectionOption;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int NumberOfAvailableMemorySize { get; init; }
    public int SupportedFrequencies { get; init; }
    public IXMP? Xmp { get; init; }
    public IFormFactor? FormFactor { get; init; }
    public IConnectionOption? ConnectionOption { get; init; }
    public int PowerConsumption { get; init; }
    public string? Name { get; init; }
}