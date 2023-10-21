using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.WiFiadapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public class TableOfWiFiadapterCharacteristics : IWiFiadatter, IPartCharacteristics
{
    public TableOfWiFiadapterCharacteristics(
        int wiFistandardversion,
        bool availabilityofbuiltBluetoothmodule,
        int pcIeversion,
        int powerconsumption)
    {
        WiFistandardversion = wiFistandardversion;
        AvailabilityofbuiltBluetoothmodule = availabilityofbuiltBluetoothmodule;
        PCIeversion = pcIeversion;
        Powerconsumption = powerconsumption;
    }

    public int WiFistandardversion { get; }
    public bool AvailabilityofbuiltBluetoothmodule { get; }
    public int PCIeversion { get; }
    public int Powerconsumption { get; }
    public string? Name { get; }
}