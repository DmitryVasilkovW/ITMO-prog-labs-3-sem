using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public static class Programm
{
    public static void Main()
    {
        var ship = new Spaceship.Models.SlowMovingShuttle();
        int fl = ship.WeightDimensionCharacteristics;
        Console.Write(fl);
    }
}