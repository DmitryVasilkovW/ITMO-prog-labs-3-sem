using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;

public class XMP : IXMP, ICloneable
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

    public object Clone()
    {
        return new XMP(
            Timings,
            Voltage,
            Frequency);
    }
}