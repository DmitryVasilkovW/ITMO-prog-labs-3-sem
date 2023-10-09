using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineAlpha : IJumpEngine
{
    public int Range(int range, int weightDimensionsOfTheShip)
    {
        return range += Math.Abs((range * 2) / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int gravitonmatter, int weightDimensionsOfTheShip)
    {
        return gravitonmatter -= Math.Abs(gravitonmatter / (2 * weightDimensionsOfTheShip));
    }
}