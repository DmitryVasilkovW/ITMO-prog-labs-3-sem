using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineGamma : IJumpEngine
{
    private string _motorOperationType;

    public JumpEngineGamma()
    {
        _motorOperationType = "Quadratic";
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public bool ISSlot()
    {
        return false;
    }

    public int Range(int range, int weightDimensionsOfTheShip)
    {
        return range += Math.Abs(range * range / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int gravitonmatter, int weightDimensionsOfTheShip)
    {
        return gravitonmatter -= Math.Abs((gravitonmatter / 2) * (gravitonmatter / 2) * weightDimensionsOfTheShip);
    }
}