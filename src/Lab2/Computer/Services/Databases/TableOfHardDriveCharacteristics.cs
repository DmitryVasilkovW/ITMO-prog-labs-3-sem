using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfHardDriveCharacteristics : IPartCharacteristics, IHardDrive
{
    public string? Name { get; init; }
    public int Capacity { get; init; }
    public int SpindleRotationSpeed { get; init; }
    public int PowerConsumption { get; init; }
}