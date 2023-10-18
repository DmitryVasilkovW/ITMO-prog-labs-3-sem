using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMP;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;

public interface IRAM
{
    int NumberOfAvailableMemorySize { get; init; }
    int SupportedFrequencies { get; init; }
    IXMP? Xmp { get; init; }
    IFormFactor? FormFactor { get; init; }
    IConnectionOption? ConnectionOption { get; init; }
    int PowerConsumption { get; init; }
}