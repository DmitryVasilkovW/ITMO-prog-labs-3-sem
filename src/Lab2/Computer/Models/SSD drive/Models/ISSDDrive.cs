using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Models;

public interface ISSDDrive
{
   public IConnectionOption? ConnectionOption { get; }
   public int Capacity { get; }
   public int MaximumOperatingSpeed { get; }
   public int PowerConsumption { get; }
}