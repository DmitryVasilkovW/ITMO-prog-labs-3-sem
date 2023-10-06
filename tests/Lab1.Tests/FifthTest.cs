using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;
using Xunit;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FifthTest
{
    public static bool ResultsVerification(Spaceship.Entities.ISpaceship shipStatus, string expectedValues)
    {
        if (shipStatus.ShipName.Equals(expectedValues, StringComparison.Ordinal))
        {
            return true;
        }

        return false;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(Spaceship.Entities.ISpaceship firstShip, Spaceship.Entities.ISpaceship secondShip, Environment environmentForFirstShip, Environment environmentForSecondShip)
    {
        IList<Spaceship.Entities.ISpaceship> ships = new List<Spaceship.Entities.ISpaceship>();
        Spaceship.Entities.ISpaceship ship;
        string expectedValue;
        IList<Environments.Entities.Environment> environments = new List<Environment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValue = "Stella";

        ship = new ShipSelection(
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
                new Augur(false),
                new Stella(false),
                new ValuesForTheEnvironment(
                    "HighDensitySpaceNebulae",
                    new Augur(true),
                    Length,
                    0,
                    2),
                new ValuesForTheEnvironment(
                    "HighDensitySpaceNebulae",
                    new Stella(false),
                    Length,
                    0,
                    239),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}