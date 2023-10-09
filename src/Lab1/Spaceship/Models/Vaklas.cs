using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Vaklas : ISpaceship
{
    public Vaklas(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 2;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        Speed = 100;
        Range = 10;
        Fuelreserve = 1;
        Armor = new SecondClassArmor();
        JumpEngine = new JumpEngineGamma();
        Engine = new ClassEPulseEngine();

        if (whethertoInstallAPhotonicDeflector)
        {
           Deflector = new FirstClassDeflector(new StandardPhotonicDeflectors());
        }
        else
        {
            Deflector = new FirstClassDeflector();
        }
    }

    public int Speed { get; private set; }

    public int Range { get; private set; }

    public IEngine Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int WeightDimensionCharacteristics { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int Fuelreserve { get; private set; }

    public void EngineWork()
    {
        Speed = Engine.Speed(Speed, WeightDimensionCharacteristics);
        Fuelreserve = Engine.FuelConsumption(Fuelreserve, WeightDimensionCharacteristics);
    }

    public void JumpEngineWork()
    {
        Range = JumpEngine.Range(Speed, WeightDimensionCharacteristics);
        Fuelreserve = JumpEngine.FuelConsumption(Fuelreserve, WeightDimensionCharacteristics);
    }

    public void SafetyEquipmentOperation()
    {
        if (Deflector.IsDeflectorWorking())
        {
            Equipment.Effect(Deflector);
        }
        else
        {
            Equipment.Effect(Armor, WeightDimensionCharacteristics);
        }
    }

    public bool IsShipAlive()
    {
        if (!Armor.IsArmorWorking())
        {
            return false;
        }

        return true;
    }

    public bool IsjumpEngineInstalled()
    {
        if (JumpEngine.ISSlot())
        {
            return false;
        }

        return true;
    }
}