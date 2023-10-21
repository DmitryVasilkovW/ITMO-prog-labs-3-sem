using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.WiFiadapter;

public class WiFiAdapter : ICloneable
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

    public object Clone()
    {
        return new WiFiAdapter(
            WiFistandardversion,
            AvailabilityofbuiltBluetoothmodule,
            PCIeversion,
            Powerconsumption);
    }

    public WiFiAdapter SetMaximumCPUCoolerHeight(int newWiFistandardversion)
    {
        var clone = (WiFiAdapter)Clone();

        clone.WiFistandardversion = newWiFistandardversion;

        return clone;
    }

    public WiFiAdapter SetMaximumCPUCoolerHeight(bool newAvailabilityofbuiltBluetoothmodule)
    {
        var clone = (WiFiAdapter)Clone();

        clone.AvailabilityofbuiltBluetoothmodule = newAvailabilityofbuiltBluetoothmodule;

        return clone;
    }

    public WiFiAdapter SetPCIeversion(int newPCIeversion)
    {
        var clone = (WiFiAdapter)Clone();

        clone.PCIeversion = newPCIeversion;

        return clone;
    }

    public WiFiAdapter SetPowerconsumption(int newPowerconsumption)
    {
        var clone = (WiFiAdapter)Clone();

        clone.Powerconsumption = newPowerconsumption;

        return clone;
    }
}