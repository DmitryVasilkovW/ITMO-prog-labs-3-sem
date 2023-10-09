using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ClassCPulseEngine : IEngine, IConstantAcceleration
{
    public int Speed(int speed, int weightDimensionsOfTheShip)
    {
        return speed += Math.Abs(100 / weightDimensionsOfTheShip);
    }

    public int FuelConsumption(int fuelreserve, int weightDimensionsOfTheShip)
    {
        return fuelreserve -= Math.Abs(10 * weightDimensionsOfTheShip);
    }
}