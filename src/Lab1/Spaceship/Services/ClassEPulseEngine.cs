using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassEPulseEngine : Entities.IEnginesType
{
    private string _motorOperationType;

    public ClassEPulseEngine()
    {
        _motorOperationType = "Exponent";
    }

    public string MotorOperationType
    {
        get { return _motorOperationType; }
    }

    public int Speed(int speed, int weightDimensionsOfTheShip)
    {
        double designspeed = speed;

        designspeed = Math.Exp(designspeed);

        speed = Math.Abs(speed) + Math.Abs((int)designspeed / weightDimensionsOfTheShip);

        return speed;
    }

    public int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip)
    {
        double fuelCalculationNumber = fuelreserve;

        fuelCalculationNumber = Math.Exp(fuelCalculationNumber);

        return fuelreserve += Math.Abs((int)fuelCalculationNumber * weightDimensionsOfTheShip);
    }
}