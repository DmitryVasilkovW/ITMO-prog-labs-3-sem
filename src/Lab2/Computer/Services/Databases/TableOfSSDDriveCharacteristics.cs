using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfSSDDriveCharacteristics : IPartCharacteristics, ISSDDrive
{
    public string? Name { get; init; }
    public IConnectionOption? ConnectionOption { get; init; }
    public int Capacity { get; init; }
    public int MaximumOperatingSpeed { get; init; }
    public int PowerConsumption { get; init; }
}