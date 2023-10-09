using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ASlowMovingShuttlecraftAndAugurInAHighDensitySpaceNebula
{
    public static bool ResultsVerification(IList<StatusOfShips> shipStatus, IList<StatusOfShips> expectedValues)
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
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        IList<StatusOfShips> shipStatus;
        IList<StatusOfShips> expectedValues = new List<StatusOfShips>();
        var environments = new List<IEnvironment>();
        IList<IList<IObstacle>> obstracles = new List<IList<IObstacle>>();
        IList<IObstacle> fleshes = new List<IObstacle>();
        int length = 50;

        for (int i = 0; i < 31; i++)
        {
            fleshes.Add(new AntimatterFlashes());
        }

        obstracles.Add(fleshes);

        var firstenvironment = new HighDensitySpaceNebulae(length, obstracles, firstShip);
        var secondenvironment = new HighDensitySpaceNebulae(length, obstracles, secondShip);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add(StatusOfShips.LossOfShip);
        expectedValues.Add(StatusOfShips.LossOfShip);

        shipStatus = new Route(environments, ships).ShipHandling();

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