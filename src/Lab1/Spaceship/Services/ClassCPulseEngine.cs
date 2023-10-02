namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassCPulseEngine : Entities.IEnginesType
{
    private int _weightDimensionsOfTheShip;

    public ClassCPulseEngine(int weightDimensionsOfTheShip)
    {
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public int Speed(int speed)
    {
        return speed += 100 / _weightDimensionsOfTheShip;
    }

    public int FuelConsumption(int fuelreserve)
    {
        return fuelreserve -= 10 * _weightDimensionsOfTheShip;
    }
}