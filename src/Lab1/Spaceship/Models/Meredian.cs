using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class Meredian : ISpaceship
{
    private int _fuelreserve;
    private int _weightDimensionCharacteristics;
    private int _gravitonmatter;
    private int _range;
    private int _nebulaDamage;

    public Meredian(bool whethertoInstallAPhotonicDeflector)
    {
        _weightDimensionCharacteristics = 2;
        _range = 100;
        ShipName = "Meredian";
        Speed = 100;
        _nebulaDamage = 1000;
        JumpEngine = new JumpEngineSlot();
        Equipment = new AntiNitrinoEmitter("SpaceWhale");
        Armor = new SecondClassArmor(_weightDimensionCharacteristics);
        Engine = new ClassEPulseEngine(_weightDimensionCharacteristics);
        EngineType = "PulseEngine";

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

    public Deflectors Deflector { get; }

    public bool IsDeflectorWorking
    {
        get { return Deflector.IsDeflectorWorking(); }
    }

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

    public string ShipName { get; }

    public IEnginesType Engine { get; }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public int WeightDimensionCharacteristics { get; }

    public string EngineType { get; }

    public void SafetyEquipmentOperation()
    {
        if (Deflector.IsDeflectorWorking())
        {
            Equipment.Effect(Deflector);
        }
        else
        {
            Equipment.Effect(Armor);
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
            _range = JumpEngine.Range(_range);
            _gravitonmatter = JumpEngine.FuelConsumption(_gravitonmatter);
        }
        else
        {
            Speed = Engine.Speed(Speed);
            _fuelreserve = Engine.FuelConsumption(_fuelreserve);
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

    public void ObstructionOfFlight()
    {
        Speed -= _nebulaDamage;
    }
}