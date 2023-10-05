using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineOmega : IJumpEngine
{
    private int _weightDimensionsOfTheShip;
    private string _motorOperationType;

    public JumpEngineOmega(int weightDimensionsOfTheShip)
    {
        _motorOperationType = "Logarithmic";
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
        double designrange = range;

        designrange = Math.Log(designrange);

        return range += Math.Abs(range * (int)designrange / _weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int gravitonmatter)
    {
        double amountoffuel = Math.Log(gravitonmatter);

        return gravitonmatter -= Math.Abs((int)amountoffuel * _weightDimensionsOfTheShip);
    }
}