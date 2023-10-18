using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;

public interface ISSDDrive
{
   public IConnectionOption? ConnectionOption { get; init; }
   public int Capacity { get; init; }
   public int MaximumOperatingSpeed { get; init; }
   public int PowerConsumption { get; init; }
}