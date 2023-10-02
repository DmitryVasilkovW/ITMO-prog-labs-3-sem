using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineAlpha : IJumpEngine
{
    public int Range(int range)
    {
        return range += range * 2;
    }

    public int FuelConsumption(int gravitonmatter)
    {
        return gravitonmatter -= gravitonmatter / 2;
    }
}