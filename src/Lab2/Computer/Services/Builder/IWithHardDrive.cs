using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithHardDrive
{
    IWithSSDDrive WithHardDrive(HardDrive hardDrive);
}