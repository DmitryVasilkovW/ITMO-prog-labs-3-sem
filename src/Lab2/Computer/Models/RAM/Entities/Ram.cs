using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;

public class Ram : IRAM, IPart, ICloneable
{
    public Ram(
        int numberOfAvailableMemorySize,
        int supportedFrequencies,
        XMP? xmp,
        IFormFactor? formFactor,
        IMemoryStandard? connectionOption,
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

    public int NumberOfAvailableMemorySize { get; private set; }
    public int SupportedFrequencies { get; private set; }
    public XMP? Xmp { get; private set; }
    public IFormFactor? FormFactor { get; private set; }
    public IMemoryStandard? ConnectionOption { get; private set; }
    public int PowerConsumption { get; private set; }
    public string? Name { get; private set; }
    public object Clone()
    {
        if (Name is not null && Xmp is not null)
        {
            return new Ram(
                NumberOfAvailableMemorySize,
                SupportedFrequencies,
                Xmp,
                FormFactor,
                ConnectionOption,
                PowerConsumption,
                (string)Name.Clone());
        }

        throw new ThePassedArgumentIsNullException();
    }

    public Ram SetName(string? newName)
    {
        var clone = (Ram)Clone();

        clone.Name = newName;

        return clone;
    }

    public Ram SetNumberOfAvailableMemorySize(int newNumberOfAvailableMemorySize)
    {
        var clone = (Ram)Clone();

        clone.NumberOfAvailableMemorySize = newNumberOfAvailableMemorySize;

        return clone;
    }

    public Ram SetSupportedFrequencies(int newSupportedFrequencies)
    {
        var clone = (Ram)Clone();

        clone.SupportedFrequencies = newSupportedFrequencies;

        return clone;
    }

    public Ram SetXmp(XMP newXmp)
    {
        var clone = (Ram)Clone();

        clone.Xmp = newXmp;

        return clone;
    }

    public Ram SetFormFactor(IFormFactor newFormFactor)
    {
        var clone = (Ram)Clone();

        clone.FormFactor = newFormFactor;

        return clone;
    }

    public Ram SetFormFactor(IMemoryStandard newConnectionOption)
    {
        var clone = (Ram)Clone();

        clone.ConnectionOption = newConnectionOption;

        return clone;
    }

    public Ram SetPowerConsumption(int newPowerConsumption)
    {
        var clone = (Ram)Clone();

        clone.PowerConsumption = newPowerConsumption;

        return clone;
    }
}