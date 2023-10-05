using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    public static bool ResultsVerification(IList<string> shipStatus, IList<string> expectedValues)
    {
        for (int i = 0; i < shipStatus.Count; i++)
        {
            for (int j = 0; j < expectedValues.Count; j++)
            {
                if (shipStatus[i] != expectedValues[j])
                    return false;
            }
        }

        return true;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(Spaceship.Entities.Spaceship firstShip, Spaceship.Entities.Spaceship secondShip, ValuesForTheEnvironment environmentForFirstShip, ValuesForTheEnvironment environmentForSecondShip)
    {
        IList<Spaceship.Entities.Spaceship> ships = new List<Spaceship.Entities.Spaceship>();
        IList<string> shipStatus;
        IList<string> expectedValues = new List<string>();
        IList<ValuesForTheEnvironment> environments = new List<ValuesForTheEnvironment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add("Destruction of the ship");
        expectedValues.Add("Destruction of the ship");

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
                new SlowMovingShuttle(),
                new Augur(false),
                new ValuesForTheEnvironment(
                    "HighDensitySpaceNebulae",
                    new SlowMovingShuttle(),
                    Length,
                    30,
                    0),
                new ValuesForTheEnvironment(
                    "HighDensitySpaceNebulae",
                    new Augur(false),
                    Length,
                    50,
                    0),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}