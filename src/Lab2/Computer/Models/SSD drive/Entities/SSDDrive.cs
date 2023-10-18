using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;

public class SSDDrive : ISSDDrive, IPart
{
    public SSDDrive(string? name, IConnectionOption? connectionOption, int capacity, int maximumOperatingSpeed, int powerConsumption)
    {
        Name = name;
        ConnectionOption = connectionOption;
        Capacity = capacity;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; init; }
    public IConnectionOption? ConnectionOption { get; init; }
    public int Capacity { get; init; }
    public int MaximumOperatingSpeed { get; init; }
    public int PowerConsumption { get; init; }
}