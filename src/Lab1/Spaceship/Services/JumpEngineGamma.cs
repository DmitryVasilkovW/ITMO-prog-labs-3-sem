using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineGamma : IJumpEngine
{
    private int _weightDimensionsOfTheShip;

    public JumpEngineGamma(int weightDimensionsOfTheShip)
    {
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public int Range(int range)
    {
        return range += range * range / _weightDimensionsOfTheShip;
    }

    public int FuelConsumption(int gravitonmatter)
    {
        return gravitonmatter -= (gravitonmatter / 2) * (gravitonmatter / 2) * _weightDimensionsOfTheShip;
    }
}