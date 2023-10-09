using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : ISpaceship
{
    public Augur(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 3;
        Equipment = new AdditionalSafetyDevicesSlot("no protection");
        Speed = 10;
        Range = 100;
        Fuelreserve = 0;
        Armor = new ThirdClassArmor();
        JumpEngine = new JumpEngineAlpha();
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

    public IEngine Engine { get; }

    public int Speed { get; private set; }

    public int Range { get; private set; }

    public IJumpEngine JumpEngine { get; }

    public int Fuelreserve { get; private set; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int WeightDimensionCharacteristics { get; }

    public bool IsjumpEngineInstalled()
    {
        if (JumpEngine.ISSlot())
        {
            return false;
        }

        return true;
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
        if (Armor.IsArmorWorking() || Deflector.IsDeflectorWorking())
        {
            return true;
        }

        return false;
    }

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
}