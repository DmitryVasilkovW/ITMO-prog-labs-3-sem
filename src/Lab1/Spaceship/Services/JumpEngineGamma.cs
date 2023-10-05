using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineGamma : IJumpEngine
{
    private int _weightDimensionsOfTheShip;
    private string _motorOperationType;

    public JumpEngineGamma(int weightDimensionsOfTheShip)
    {
        _motorOperationType = "Quadratic";
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public bool ISSlot()
    {
        return false;
    }

    public int Range(int range)
    {
        return range += Math.Abs(range * range / _weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int gravitonmatter)
    {
        return gravitonmatter -= Math.Abs((gravitonmatter / 2) * (gravitonmatter / 2) * _weightDimensionsOfTheShip);
    }
}