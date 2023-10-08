using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SlowMovingShuttleAndAugurInHighDensitySpaceAndNitrinoParticleNebulae
{
    public static bool ResultsVerification(IList<string> shipStatus, IList<string> expectedValues)
    {
        int indexForShip = 0;

        for (int i = 0; i < expectedValues.Count; i += 2)
        {
            if (shipStatus[indexForShip] != expectedValues[i])
            {
                return false;
            }

            indexForShip++;
        }

        return true;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(Spaceship.Entities.ISpaceship firstShip, Spaceship.Entities.ISpaceship secondShip, IEnvironment environmentForFirstShip, IEnvironment environmentForSecondShip, IEnvironment secondEnvironmentForFirstShip, IEnvironment secondEnvironmentForSecondShip)
    {
        IList<Spaceship.Entities.ISpaceship> ships = new List<Spaceship.Entities.ISpaceship>();
        IList<string> shipStatus;
        IList<string> expectedValues = new List<string>();
        var environments = new List<IEnvironment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
        environments.Add(secondEnvironmentForFirstShip);
        environments.Add(secondEnvironmentForSecondShip);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add("Loss of ship");
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
                new HighDensitySpaceNebulae(Length, 30, new SlowMovingShuttle()),
                new HighDensitySpaceNebulae(Length, 50, new Augur(false)),
                new NitrinoParticleNebulae(Length, 0, new SlowMovingShuttle()),
                new NitrinoParticleNebulae(Length, 0, new Augur(false)),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}