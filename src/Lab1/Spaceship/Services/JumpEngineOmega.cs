using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineOmega : IJumpEngine
{
    public int Range(int range, int weightDimensionsOfTheShip)
    {
        double designrange = range;

        designrange = Math.Log(designrange);

        return range += Math.Abs(range * (int)designrange / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int gravitonmatter, int weightDimensionsOfTheShip)
    {
        double amountoffuel = Math.Log(gravitonmatter);

        return gravitonmatter -= Math.Abs((int)amountoffuel * weightDimensionsOfTheShip);
    }
}