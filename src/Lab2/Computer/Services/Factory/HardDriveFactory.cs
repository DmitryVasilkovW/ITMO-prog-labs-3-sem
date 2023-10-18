using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class HardDriveFactory : IPartFactory<HardDrive, TableOfHardDriveCharacteristics>
{
    public HardDrive CreatePart(TableOfHardDriveCharacteristics characteristics)
    {
        string? name = characteristics.Name;
        int capacity = characteristics.Capacity;
        int spindleRotationSpeed = characteristics.SpindleRotationSpeed;
        int powerConsumption = characteristics.PowerConsumption;

        return new HardDrive(name, capacity, spindleRotationSpeed, powerConsumption);
    }
}