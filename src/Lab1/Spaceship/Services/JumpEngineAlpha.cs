using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineAlpha : IJumpEngine
{
    private const int Coefficient = 2;
    public int Range(int range, int weightDimensionsOfTheShip)
    {
        return range += Math.Abs((range * Coefficient) / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int gravitonmatter, int weightDimensionsOfTheShip)
    {
        return gravitonmatter -= Math.Abs(gravitonmatter / (Coefficient * weightDimensionsOfTheShip));
    }
}