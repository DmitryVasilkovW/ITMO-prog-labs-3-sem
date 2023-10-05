using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;
using Xunit;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FourthTest
{
    public static bool ResultsVerification(Spaceship.Entities.Spaceship shipStatus, string expectedValues)
    {
        if (shipStatus.ShipName.Equals(expectedValues, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(Spaceship.Entities.Spaceship firstShip, Spaceship.Entities.Spaceship secondShip, Environment environmentForFirstShip, Environment environmentForSecondShip)
    {
        IList<Spaceship.Entities.Spaceship> ships = new List<Spaceship.Entities.Spaceship>();
        Spaceship.Entities.Spaceship ship;
        string expectedValue;
        IList<Environments.Entities.Environment> environments = new List<Environment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValue = "SlowMovingShuttle";

        ship = new Environments.Services.ShipSelection(
            ships,
            new FuelExchange(2, 3, 4, 5, 6, 7, 8, 9),
            environments,
            100).Select();

        Assert.True(ResultsVerification(ship, expectedValue));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private const int Length = 100;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new SlowMovingShuttle(),
                new Vaklas(false),
                new NormalSpace(Length, 0, 0, new SlowMovingShuttle()),
                new NormalSpace(Length, 0, 0, new Vaklas(false)),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}