using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;

public class HardDrive : IHardDrive, IPart
{
    public HardDrive(string? name, int capacity, int spindleRotationSpeed, int powerConsumption)
    {
        Name = name;
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        PowerConsumption = powerConsumption;
    }

    public string? Name { get; init; }
    public int Capacity { get; init; }
    public int SpindleRotationSpeed { get; init; }
    public int PowerConsumption { get; init; }
}