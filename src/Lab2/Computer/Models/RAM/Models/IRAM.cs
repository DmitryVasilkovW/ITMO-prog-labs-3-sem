using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;

public interface IRAM
{
    int NumberOfAvailableMemorySize { get; }
    int SupportedFrequencies { get; }
    XMP? Xmp { get; }
    IFormFactor? FormFactor { get; }
    IMemoryStandard? ConnectionOption { get; }
    int PowerConsumption { get; }
}