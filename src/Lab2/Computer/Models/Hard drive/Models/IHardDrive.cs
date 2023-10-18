namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Models;

public interface IHardDrive
{
    int Capacity { get; init; }
    int SpindleRotationSpeed { get; init; }
    int PowerConsumption { get; init; }
}