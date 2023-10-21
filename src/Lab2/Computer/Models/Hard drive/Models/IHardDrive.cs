namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Models;

public interface IHardDrive
{
    int Capacity { get; }
    int SpindleRotationSpeed { get; }
    int PowerConsumption { get; }
}