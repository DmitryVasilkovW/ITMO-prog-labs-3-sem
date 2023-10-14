using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassCPulseEngine : IEngine, IConstantAcceleration
{
    private const int SpeedBoost = 100;
    private const int IncreasingFuelConsumption = 10;
    public int Speed(int speed, int weightDimensionsOfTheShip)
    {
        return speed += Math.Abs(SpeedBoost / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip)
    {
        return fuelreserve -= Math.Abs(IncreasingFuelConsumption * weightDimensionsOfTheShip);
    }
}