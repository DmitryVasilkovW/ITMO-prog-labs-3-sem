using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;

public class XMP : IXMP, IPrototype<XMP>
{
    public XMP(int timings, int voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public int Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public XMP Clone()
    {
        return new XMP(
            Timings,
            Voltage,
            Frequency);
    }
}