namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.WiFiadapter;

public interface IWiFiadatter
{
    int WiFistandardversion { get; }
    bool AvailabilityofbuiltBluetoothmodule { get; }
    int PCIeversion { get; }
    int Powerconsumption { get; }
}