using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfSSDDriveCharacteristics : IPartCharacteristics, ISSDDrive
{
    public TableOfSSDDriveCharacteristics(
        string name,
        IConnectionOption connectionOption,
        int capacity,
        int maximumOperatingSpeed,
        int powerConsumption)
    {
        Name = name;
        ConnectionOption = connectionOption;
        Capacity = capacity;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; }
    public IConnectionOption? ConnectionOption { get; }
    public int Capacity { get; }
    public int MaximumOperatingSpeed { get; init; }
    public int PowerConsumption { get; init; }
}