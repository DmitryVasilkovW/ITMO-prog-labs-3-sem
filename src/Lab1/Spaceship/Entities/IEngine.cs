namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IEngine
{
    int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip);

    int Speed(int speed, int weightDimensionsOfTheShip);
}