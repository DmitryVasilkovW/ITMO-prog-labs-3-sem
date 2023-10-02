using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineGamma : IJumpEngine
{
    public int Range(int range)
    {
        return range += range * range;
    }

    public int FuelConsumption(int gravitonmatter)
    {
        return gravitonmatter -= (gravitonmatter / 2) * (gravitonmatter / 2);
    }
}