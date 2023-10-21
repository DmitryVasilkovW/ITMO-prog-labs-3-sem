using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.WiFiadapter;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class WiFiadapterFactory : IPartFactory<WiFiAdapter, TableOfWiFiadapterCharacteristics>
{
    public WiFiAdapter CreatePart(TableOfWiFiadapterCharacteristics characteristics)
    {
        return new WiFiAdapter(
            characteristics.WiFistandardversion,
            characteristics.AvailabilityofbuiltBluetoothmodule,
            characteristics.PCIeversion,
            characteristics.Powerconsumption);
    }
}