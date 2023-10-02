using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassEPulseEngine : Entities.IEnginesType
{
    private int _weightDimensionsOfTheShip;

    public ClassEPulseEngine(int weightDimensionsOfTheShip)
    {
        _weightDimensionsOfTheShip = weightDimensionsOfTheShip;
    }

    public int Speed(int speed)
    {
        double designspeed = speed;

        designspeed = Math.Exp(designspeed);

        return speed += (int)designspeed / _weightDimensionsOfTheShip;
    }

    public int FuelConsumption(int fuelreserve)
    {
        double fuelCalculationNumber = fuelreserve;

        fuelCalculationNumber = Math.Exp(fuelCalculationNumber);

        return fuelreserve += (int)fuelCalculationNumber * _weightDimensionsOfTheShip;
    }
}