using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;

public class Processor : ICPU, IPart, IPrototype<Processor>
{
    public Processor(
        string? name,
        bool availabilityOfABuiltInVideoCore,
        int supportedMemoryFrequencies,
        int heatEmission,
        int consumptionPower,
        int coreFrequency,
        int numberOfCores,
        ISocket? socket)
    {
        Name = name;
        AvailabilityOfABuiltInVideoCore = availabilityOfABuiltInVideoCore;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        HeatEmission = heatEmission;
        ConsumptionPower = consumptionPower;
        CoreFrequency = coreFrequency;
        NumberOfCores = numberOfCores;
        Socket = socket;
    }

    public string? Name { get; private set; }
    public bool AvailabilityOfABuiltInVideoCore { get; private set; }
    public int SupportedMemoryFrequencies { get; private set; }
    public int HeatEmission { get; private set; }
    public int ConsumptionPower { get; private set; }
    public int CoreFrequency { get; private set; }
    public int NumberOfCores { get; private set; }
    public ISocket? Socket { get; private set; }

    public Processor Clone()
    {
        if (Name is not null)
        {
            return new Processor(
                (string)Name.Clone(),
                AvailabilityOfABuiltInVideoCore,
                SupportedMemoryFrequencies,
                HeatEmission,
                ConsumptionPower,
                CoreFrequency,
                NumberOfCores,
                Socket);
        }

        throw new ThePassedArgumentIsNullException();
    }

    public Processor SetName(string? newName)
    {
        Processor clone = Clone();

        clone.Name = newName;

        return clone;
    }

    public Processor SetavailabilityOfABuiltInVideoCore(bool newavailabilityOfABuiltInVideoCore)
    {
        Processor clone = Clone();

        clone.AvailabilityOfABuiltInVideoCore = newavailabilityOfABuiltInVideoCore;

        return clone;
    }

    public Processor SetSupportedMemoryFrequencies(int newSupportedMemoryFrequencies)
    {
        Processor clone = Clone();

        clone.SupportedMemoryFrequencies = newSupportedMemoryFrequencies;

        return clone;
    }

    public Processor SetHeatEmission(int newHeatEmission)
    {
        Processor clone = Clone();

        clone.HeatEmission = newHeatEmission;

        return clone;
    }

    public Processor SetConsumptionPower(int newConsumptionPower)
    {
        Processor clone = Clone();

        clone.ConsumptionPower = newConsumptionPower;

        return clone;
    }

    public Processor SetCoreFrequency(int newCoreFrequency)
    {
        Processor clone = Clone();

        clone.CoreFrequency = newCoreFrequency;

        return clone;
    }

    public Processor SetNumberOfCores(int newNumberOfCores)
    {
        Processor clone = Clone();

        clone.NumberOfCores = newNumberOfCores;

        return clone;
    }

    public Processor SetSocket(ISocket newSocket)
    {
        Processor clone = Clone();

        clone.Socket = newSocket;

        return clone;
    }
}