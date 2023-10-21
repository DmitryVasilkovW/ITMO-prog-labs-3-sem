using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithSSDDrive
{
    IWithVideoCard WithSSDDrive(SSDDrive ssdDrive);
}