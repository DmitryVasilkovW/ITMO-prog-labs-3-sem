using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class SSDDriveFactory : IPartFactory<SSDDrive, TableOfSSDDriveCharacteristics>
{
    public SSDDrive CreatePart(TableOfSSDDriveCharacteristics characteristics)
    {
        string? name = characteristics.Name;
        IConnectionOption? connectionOption = characteristics.ConnectionOption;
        int capacity = characteristics.Capacity;
        int maximumOperatingSpeed = characteristics.MaximumOperatingSpeed;
        int powerConsumption = characteristics.PowerConsumption;

        return new SSDDrive(name, connectionOption, capacity, maximumOperatingSpeed, powerConsumption);
    }
}