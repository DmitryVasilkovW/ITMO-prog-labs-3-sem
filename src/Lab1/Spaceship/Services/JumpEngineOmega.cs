using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineOmega : IJumpEngine
{
    public int Range(int range)
    {
        double designrange = range;

        designrange = Math.Log(designrange);

        return range += range * (int)designrange;
    }

    public int FuelConsumption(int gravitonmatter)
    {
        double amountoffuel = Math.Log(gravitonmatter);

        return gravitonmatter -= (int)amountoffuel;
    }
}