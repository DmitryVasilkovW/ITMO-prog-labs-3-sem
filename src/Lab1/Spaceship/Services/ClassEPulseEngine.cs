using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassEPulseEngine : Entities.IEnginesType
{
    public int Speed(int speed)
    {
        double designspeed = speed;

        designspeed = Math.Exp(designspeed);

        return speed += (int)designspeed;
    }

    public int FuelConsumption(int fuelreserve)
    {
        double fuelCalculationNumber = fuelreserve;

        fuelCalculationNumber = Math.Exp(fuelCalculationNumber);

        return fuelreserve += (int)fuelCalculationNumber;
    }
}