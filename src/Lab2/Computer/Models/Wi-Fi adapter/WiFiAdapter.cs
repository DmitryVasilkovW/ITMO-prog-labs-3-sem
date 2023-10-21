using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Prototype;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.WiFiadapter;

public class WiFiAdapter : IPrototype<WiFiAdapter>
{
    public WiFiAdapter(
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

    public int WiFistandardversion { get; private set; }
    public bool AvailabilityofbuiltBluetoothmodule { get; private set; }
    public int PCIeversion { get; private set; }
    public int Powerconsumption { get; private set; }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(
            WiFistandardversion,
            AvailabilityofbuiltBluetoothmodule,
            PCIeversion,
            Powerconsumption);
    }

    public WiFiAdapter SetMaximumCPUCoolerHeight(int newWiFistandardversion)
    {
        WiFiAdapter clone = Clone();

        clone.WiFistandardversion = newWiFistandardversion;

        return clone;
    }

    public WiFiAdapter SetMaximumCPUCoolerHeight(bool newAvailabilityofbuiltBluetoothmodule)
    {
        WiFiAdapter clone = Clone();

        clone.AvailabilityofbuiltBluetoothmodule = newAvailabilityofbuiltBluetoothmodule;

        return clone;
    }

    public WiFiAdapter SetPCIeversion(int newPCIeversion)
    {
        WiFiAdapter clone = Clone();

        clone.PCIeversion = newPCIeversion;

        return clone;
    }

    public WiFiAdapter SetPowerconsumption(int newPowerconsumption)
    {
        WiFiAdapter clone = Clone();

        clone.Powerconsumption = newPowerconsumption;

        return clone;
    }
}