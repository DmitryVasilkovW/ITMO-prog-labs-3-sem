using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : ISpaceship
{
    private int _fuelreserve;
    private int _gravitonmatter;
    private int _range;

    public Meredian(bool whethertoInstallAPhotonicDeflector)
    {
        WeightDimensionCharacteristics = 2;
        _range = 10;
        Speed = 100;
        JumpEngine = new JumpEngineSlot();
        Equipment = new AntiNitrinoEmitter("SpaceWhale");
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

    public int Fuelreserve
    {
        get
        {
            EngineWork();
            return _fuelreserve;
        }
    }

    public IArmor Armor { get; }

    public int Speed { get; private set; }

    public IEngine Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int WeightDimensionCharacteristics { get; }

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

    public bool IsjumpEngineInstalled()
    {
        if (JumpEngine.ISSlot())
        {
            return false;
        }

        return true;
    }
}