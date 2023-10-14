namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IJumpEngine
{
    int Range(int range, int weightDimensionsOfTheShip);
    int FuelConsumption(int gravitonmatter, int weightDimensionsOfTheShip);
}