using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : ISpaceship
{
    public Meredian(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 2;
        Range = 10;
        Speed = 100;
        JumpEngine = new JumpEngineSlot();
        Equipment = new AntiNitrinoEmitter();
        Armor = new SecondClassArmor();
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

    public Deflectors Deflector { get; }

    public int Fuelreserve { get; private set; }
    public IArmor Armor { get; }

    public int Speed { get; private set; }

    public int Range { get; private set; }

    public IEngine Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int WeightDimensionCharacteristics { get; }

    public void SafetyEquipmentOperation()
    {
        if (Deflector.IsDeflectorWorking())
        {
            Equipment.Effect(Deflector, Equipment);
        }
        else
        {
            Equipment.Effect(Armor, WeightDimensionCharacteristics, Equipment);
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