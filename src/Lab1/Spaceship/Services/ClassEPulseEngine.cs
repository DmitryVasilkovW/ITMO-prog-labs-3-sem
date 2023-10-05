using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassEPulseEngine : Entities.IEnginesType
{
    private int _weightDimensionsOfTheShip;
    private string _motorOperationType;

    public ClassEPulseEngine(int weightDimensionsOfTheShip)
    {
        _motorOperationType = "Exponent";
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public int Speed(int speed)
    {
        double designspeed = speed;

        designspeed = Math.Exp(designspeed);

        return speed += Math.Abs((int)designspeed / _weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int fuelreserve)
    {
        double fuelCalculationNumber = fuelreserve;

        fuelCalculationNumber = Math.Exp(fuelCalculationNumber);

        return fuelreserve += Math.Abs((int)fuelCalculationNumber * _weightDimensionsOfTheShip);
    }
}