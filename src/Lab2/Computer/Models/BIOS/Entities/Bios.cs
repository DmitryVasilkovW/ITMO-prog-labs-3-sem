using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;

public class Bios : IBios, IPrototype<Bios>
{
    public Bios(int version, IList<ICPU> processors)
    {
        Version = version;
        ListOfSupportedCPUs = processors;
    }

    public int Version { get; private set; }
    public IList<ICPU>? ListOfSupportedCPUs { get; private set; }
    public Bios Clone()
    {
        if (ListOfSupportedCPUs is not null)
        {
            return new Bios(
                Version,
                ListOfSupportedCPUs);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public Bios SetVersion(int newVersion)
    {
        Bios clone = Clone();

        clone.Version = newVersion;

        return clone;
    }

    public Bios SetListOfSupportedCPUs(IList<ICPU> newListOfSupportedCPUs)
    {
        Bios clone = Clone();

        clone.ListOfSupportedCPUs = newListOfSupportedCPUs;

        return clone;
    }
}