using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Augur : ISpaceship
{
    private const int InitialSpeed = 10;
    private const int InitialRange = 100;
    private const int InitialFuelreserve = 1;
    private const int InitialWeightDimensionCharacteristics = 3;

    public Augur(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = InitialWeightDimensionCharacteristics;
        Equipment = new AdditionalSafetyDevicesSlot();
        Speed = InitialSpeed;
        Range = InitialRange;
        Fuelreserve = InitialFuelreserve;
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