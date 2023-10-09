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
    public void ShipsAndEnvironments(Spaceship.Entities.ISpaceship firstShip, Spaceship.Entities.ISpaceship secondShip)
    {
        IList<Spaceship.Entities.ISpaceship> ships = new List<Spaceship.Entities.ISpaceship>();
        IList<string> shipStatus;
        IList<string> expectedValues = new List<string>();
        var environments = new List<IEnvironment>();
        IList<IList<IObstacle>> obstracles = new List<IList<IObstacle>>();
        IList<IList<IObstacle>> obstraclesforNitrinoParticleNebulae = new List<IList<IObstacle>>();
        IList<IObstacle> fleshes = new List<IObstacle>();

        for (int i = 0; i < 31; i++)
        {
            fleshes.Add(new AntimatterFlashes());
        }

        obstracles.Add(fleshes);

        var firstenvironment = new HighDensitySpaceNebulae(239, obstracles, firstShip);
        var secondenvironment = new HighDensitySpaceNebulae(239, obstracles, secondShip);
        var thirdenvironment = new NitrinoParticleNebulae(239, obstraclesforNitrinoParticleNebulae, firstShip);
        var fourthenvironment = new NitrinoParticleNebulae(239, obstraclesforNitrinoParticleNebulae, secondShip);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        environments.Add(thirdenvironment);
        environments.Add(fourthenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add("Loss of ship");
        expectedValues.Add("Destruction of the ship");

        shipStatus = new Route(239, environments, ships).ShipHandling();

        Assert.True(ResultsVerification(shipStatus, expectedValues));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new SlowMovingShuttle(),
                new Augur(false),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}