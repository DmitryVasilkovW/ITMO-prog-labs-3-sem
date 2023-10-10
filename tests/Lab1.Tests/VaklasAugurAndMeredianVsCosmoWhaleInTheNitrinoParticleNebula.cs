using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class VaklasAugurAndMeredianVsCosmoWhaleInTheNitrinoParticleNebula
{
    public static bool ResultsVerification(IList<StatusOfShips> shipStatus, IList<StatusOfShips> expectedValues)
    {
        for (int i = 0; i < shipStatus.Count; i++)
        {
            if (shipStatus[i] != expectedValues[i])
            {
                return false;
            }
        }

        return true;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip, ISpaceship thirdship)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        IList<StatusOfShips> shipStatus;
        IList<StatusOfShips> expectedValues = new List<StatusOfShips>();
        var environments = new List<IEnvironment>();
        IList<IObstacle> spacewhiles = new List<IObstacle>();
        IList<IObstacle> spacewhilesforVaklas = new List<IObstacle>();
        const int countofobstacles = 3;
        const int length = 1;

        for (int i = 0; i < countofobstacles; i++)
        {
            spacewhilesforVaklas.Add(new SpaceWhale());
        }

        spacewhiles.Add(new SpaceWhale());

        var firstenvironment = new NitrinoParticleNebulae(length, spacewhilesforVaklas);
        var secondenvironment = new NitrinoParticleNebulae(length, spacewhiles);
        var thirdenvironment = new NitrinoParticleNebulae(length, spacewhiles);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        environments.Add(thirdenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        ships.Add(thirdship);
        expectedValues.Add(StatusOfShips.DestructionOfTheShip);
        expectedValues.Add(StatusOfShips.Success);
        expectedValues.Add(StatusOfShips.Success);

        shipStatus = new Route().ShipHandling(ships, environments);

        Assert.True(ResultsVerification(shipStatus, expectedValues));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new Vaklas(false),
                new Augur(false),
                new Meredian(false),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}