using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;

public class SlowMovingShuttle : ISpaceship
{
    private const int InitialSpeed = 100;
    private const int InitialRange = 0;
    private const int InitialFuelreserve = 1;
    private const int InitialWeightDimensionCharacteristics = 1;
    private IList<IShipDefense> _shipDefenses = new List<IShipDefense>();
    public SlowMovingShuttle()
    {
        WeightDimensionCharacteristics = InitialWeightDimensionCharacteristics;
        Equipment = new AdditionalSafetyDevicesSlot();
        Deflector = new DeflectorSlot();
        JumpEngine = new JumpEngineSlot();
        Speed = InitialSpeed;
        Range = InitialRange;
        Fuelreserve = InitialFuelreserve;
        Armor = new FirstClassArmor();
        Engine = new ClassCPulseEngine();
    }

    public IJumpEngine JumpEngine { get; }

    public AdditionalSafetyDevices Equipment { get; }

    public Deflectors Deflector { get; }

    public IArmor Armor { get; }

    public int Speed { get; private set; }

    public int Range { get; private set; }

    public IEngine Engine { get; }

    public int WeightDimensionCharacteristics { get; }

    public int Fuelreserve { get; private set; }

    public void SafetyEquipmentOperation()
    {
        if (Deflector.IsWorking())
        {
            Equipment.Effect(Deflector, Equipment);
        }
        else
        {
            Equipment.Effect(Armor, WeightDimensionCharacteristics, Equipment);
        }
    }

    public void ProtectionFromObstacles(IObstacle obstacle)
    {
        bool isTheDefenseSucceeded = false;

        foreach (IShipDefense defense in _shipDefenses)
        {
            if (defense.IsWorking())
            {
                switch (obstacle)
                {
                    case Asteroid:
                        defense.AsteroidDamage();
                        isTheDefenseSucceeded = true;
                        break;
                    case Meteorite:
                        defense.MeteoriteDamage();
                        isTheDefenseSucceeded = true;
                        break;
                    case SpaceWhale:
                        defense.SpaceWhaleDamage();
                        if (Equipment is ISpaceWhaleDefense)
                        {
                            SafetyEquipmentOperation();
                        }

                        isTheDefenseSucceeded = true;
                        break;
                    default:
                        throw new IncorrectObstacleTypeException();
                }
            }
        }

        if (!isTheDefenseSucceeded)
        {
            switch (obstacle)
            {
                case Asteroid:
                    Armor.AsteroidDamage(WeightDimensionCharacteristics);
                    break;
                case Meteorite:
                    Armor.MeteoriteDamage(WeightDimensionCharacteristics);
                    break;
                case SpaceWhale:
                    Armor.SpaceWhaleDamage(WeightDimensionCharacteristics);
                    break;
                default:
                    throw new IncorrectObstacleTypeException();
            }
        }
    }

    public bool IsShipAlive()
    {
        if (Armor.IsArmorWorking())
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