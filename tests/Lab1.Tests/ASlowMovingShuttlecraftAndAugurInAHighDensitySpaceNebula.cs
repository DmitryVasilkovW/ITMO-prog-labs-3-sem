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
        IList<IObstacle> fleshes = new List<IObstacle>();
        const int length = 50;
        const int countofobstacles = 31;

        for (int i = 0; i < countofobstacles; i++)
        {
            fleshes.Add(new AntimatterFlashes());
        }

        var firstenvironment = new HighDensitySpaceNebulae(length, fleshes);

        environments.Add(firstenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add(StatusOfShips.LossOfShip);
        expectedValues.Add(StatusOfShips.LossOfShip);

        shipStatus = new Route().ShipHandling(ships, environments);

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