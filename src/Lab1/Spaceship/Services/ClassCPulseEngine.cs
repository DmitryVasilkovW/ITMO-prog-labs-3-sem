using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassCPulseEngine : Entities.IEnginesType
{
    private string _motorOperationType;

    public ClassCPulseEngine()
    {
        _motorOperationType = "Constant";
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public int Speed(int speed, int weightDimensionsOfTheShip)
    {
        return speed += Math.Abs(100 / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip)
    {
        return fuelreserve -= Math.Abs(10 * weightDimensionsOfTheShip);
    }
}