using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ASlowMovingShuttlecraftAndAugurInAHighDensitySpaceNebula
{
    public static bool ResultsVerification(IList<string> shipStatus, IList<string> expectedValues)
    {
        for (int i = 0; i < shipStatus.Count; i++)
        {
            if (shipStatus[i] != expectedValues[i])
                return false;
        }

        return true;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip, IEnvironment environmentForFirstShip, IEnvironment environmentForSecondShip)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        IList<string> shipStatus;
        IList<string> expectedValues = new List<string>();
        var environments = new List<IEnvironment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add("Loss of ship");
        expectedValues.Add("Crew deaths");

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
                new HighDensitySpaceNebulae(Length, 30, new SlowMovingShuttle()),
                new HighDensitySpaceNebulae(Length, 30, new Augur(false)),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}