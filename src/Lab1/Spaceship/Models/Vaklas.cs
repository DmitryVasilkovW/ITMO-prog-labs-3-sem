using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Vaklas : ISpaceship
{
    private int _range;
    private int _fuelreserve;
    private int _gravitonmatter;

    public Vaklas(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 2;
        Equipment = new AdditionalSafetyDevicesSlot("none");
        Speed = 100;
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

    public bool IsPhotonDeflectorWorking
    {
        get { return Deflector.IsaPhotonDeflectorInstalled; }
    }

    public int Speed { get; private set; }

    public IEngine Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int WeightDimensionCharacteristics { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int Fuelreserve
    {
        get
        {
            EngineWork();
            return _fuelreserve;
        }
    }

    public bool IsDeflectorWorking
    {
        get { return Deflector.IsDeflectorWorking(); }
    }

    public void EngineWork()
    {
        if (JumpEngine is not JumpEngineSlot)
        {
            _range = JumpEngine.Range(_range, WeightDimensionCharacteristics);
            _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter, WeightDimensionCharacteristics);
        }
        else
        {
            Speed = Engine.Speed(Speed, WeightDimensionCharacteristics);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve, WeightDimensionCharacteristics);
        }
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