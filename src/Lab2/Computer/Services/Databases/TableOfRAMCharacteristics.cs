using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfRAMCharacteristics : IRAM, IPartCharacteristics
{
    public TableOfRAMCharacteristics(
        int numberOfAvailableMemorySize,
        int supportedFrequencies,
        XMP xmp,
        IFormFactor formFactor,
        IMemoryStandard connectionOption,
        int powerConsumption,
        string name)
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
    public XMP? Xmp { get; init; }
    public IFormFactor? FormFactor { get; init; }
    public IMemoryStandard? ConnectionOption { get; init; }
    public int PowerConsumption { get; init; }
    public string? Name { get; init; }
}