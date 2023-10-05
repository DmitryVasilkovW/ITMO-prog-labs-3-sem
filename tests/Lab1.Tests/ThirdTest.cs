using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ThirdTest
{
    public static bool ResultsVerification(IList<string> shipStatus, IList<string> expectedValues)
    {
        for (int i = 0; i < shipStatus.Count; i++)
        {
            if (!shipStatus[i].Equals(expectedValues[i], StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(Spaceship.Entities.Spaceship firstShip, Spaceship.Entities.Spaceship secondShip, Spaceship.Entities.Spaceship thirdship, ValuesForTheEnvironment environmentForFirstShip, ValuesForTheEnvironment environmentForSecondShip, ValuesForTheEnvironment environmentForThirdShip)
    {
        IList<Spaceship.Entities.Spaceship> ships = new List<Spaceship.Entities.Spaceship>();
        IList<string> shipStatus;
        IList<string> expectedValues = new List<string>();
        IList<ValuesForTheEnvironment> environments = new List<ValuesForTheEnvironment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
        environments.Add(environmentForThirdShip);
        ships.Add(firstShip);
        ships.Add(secondShip);
        ships.Add(thirdship);
        expectedValues.Add("Destruction of the ship");
        expectedValues.Add("Success");
        expectedValues.Add("Success");

        shipStatus = new Route(239, environments, ships).ShipHandling();

        Assert.True(ResultsVerification(shipStatus, expectedValues));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private const int Length = 239;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new Vaklas(false),
                new Augur(false),
                new Meredian(false),
                new ValuesForTheEnvironment(
                    "NitrinoParticleNebulae",
                    new Vaklas(false),
                    Length,
                    10,
                    0),
                new ValuesForTheEnvironment(
                    "NitrinoParticleNebulae",
                    new Augur(false),
                    Length,
                    1,
                    0),
                new ValuesForTheEnvironment(
                    "NitrinoParticleNebulae",
                    new Meredian(false),
                    Length,
                    1,
                    0),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}