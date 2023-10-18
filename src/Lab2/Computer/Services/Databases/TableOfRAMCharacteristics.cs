using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfRAMCharacteristics : IRAM, IPartCharacteristics
{
    public int NumberOfAvailableMemorySize { get; init; }
    public int SupportedFrequencies { get; init; }
    public IXMP? Xmp { get; init; }
    public IFormFactor? FormFactor { get; init; }
    public IConnectionOption? ConnectionOption { get; init; }
    public int PowerConsumption { get; init; }
    public string? Name { get; init; }
}