using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassEPulseEngine : IEngine, IExponentialAcceleration
{
    public int Speed(int speed, int weightDimensionsOfTheShip)
    {
        double designspeed = speed;

        designspeed = Math.Exp(designspeed);

        speed = Math.Abs(speed) + Math.Abs((int)designspeed / weightDimensionsOfTheShip);

        return Math.Abs(speed);
    }

    public int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip)
    {
        double fuelCalculationNumber = fuelreserve;

        fuelCalculationNumber = Math.Exp(fuelCalculationNumber);

        return fuelreserve += Math.Abs((int)fuelCalculationNumber * weightDimensionsOfTheShip);
    }
}