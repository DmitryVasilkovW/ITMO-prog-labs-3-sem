namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class JumpEngineSlot : Entities.IJumpEngine
{
    public bool ISSlot()
    {
        return true;
    }

    public int Range(int range, int weightDimensionsOfTheShip)
    {
        return 0;
    }

    public int FuelConsumption(int gravitonmatter, int weightDimensionsOfTheShip)
    {
        return 0;
    }
}