namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassCPulseEngine : Entities.IEnginesType
{
    public int Speed(int speed)
    {
        return speed += 100;
    }

    public int FuelConsumption(int fuelreserve)
    {
        return fuelreserve -= 10;
    }
}