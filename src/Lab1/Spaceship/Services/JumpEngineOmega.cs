using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineOmega : IJumpEngine
{
    private int _weightDimensionsOfTheShip;

    public JumpEngineOmega(int weightDimensionsOfTheShip)
    {
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public int Range(int range)
    {
        double designrange = range;

        designrange = Math.Log(designrange);

        return range += range * (int)designrange / _weightDimensionsOfTheShip;
    }

    public int FuelConsumption(int gravitonmatter)
    {
        double amountoffuel = Math.Log(gravitonmatter);

        return gravitonmatter -= (int)amountoffuel * _weightDimensionsOfTheShip;
    }
}