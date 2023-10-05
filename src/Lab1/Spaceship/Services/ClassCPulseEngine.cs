using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassCPulseEngine : Entities.IEnginesType
{
    private int _weightDimensionsOfTheShip;
    private string _motorOperationType;

    public ClassCPulseEngine(int weightDimensionsOfTheShip)
    {
        _motorOperationType = "Constant";
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public int Speed(int speed)
    {
        return speed += Math.Abs(100 / _weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int fuelreserve)
    {
        return fuelreserve -= Math.Abs(10 * _weightDimensionsOfTheShip);
    }
}