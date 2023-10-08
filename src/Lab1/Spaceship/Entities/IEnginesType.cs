namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public interface IEnginesType
{
    string MotorOperationType { get; }
    int Speed(int speed, int weightDimensionsOfTheShip);
    int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip);
}