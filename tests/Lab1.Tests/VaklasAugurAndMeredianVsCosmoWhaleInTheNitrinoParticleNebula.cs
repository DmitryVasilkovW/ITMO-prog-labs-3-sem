using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
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
    public void ShipsAndEnvironments(Spaceship.Entities.ISpaceship firstShip, Spaceship.Entities.ISpaceship secondShip, Spaceship.Entities.ISpaceship thirdship)
    {
        IList<Spaceship.Entities.ISpaceship> ships = new List<Spaceship.Entities.ISpaceship>();
        IList<StatusOfShips> shipStatus;
        IList<StatusOfShips> expectedValues = new List<StatusOfShips>();
        var environments = new List<IEnvironment>();
        IList<IList<IObstacle>> obstracles = new List<IList<IObstacle>>();
        IList<IList<IObstacle>> obstraclesforVaklas = new List<IList<IObstacle>>();
        IList<IObstacle> spacewhiles = new List<IObstacle>();
        IList<IObstacle> spacewhilesforVaklas = new List<IObstacle>();

        for (int i = 0; i < 31; i++)
        {
            spacewhilesforVaklas.Add(new SpaceWhale());
        }

        spacewhiles.Add(new SpaceWhale());

        obstracles.Add(spacewhiles);
        obstraclesforVaklas.Add(spacewhilesforVaklas);

        var firstenvironment = new NitrinoParticleNebulae(1, obstraclesforVaklas, firstShip);
        var secondenvironment = new NitrinoParticleNebulae(1, obstracles, secondShip);
        var thirdenvironment = new NitrinoParticleNebulae(1, obstracles, thirdship);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        environments.Add(thirdenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        ships.Add(thirdship);
        expectedValues.Add(StatusOfShips.DestructionOfTheShip);
        expectedValues.Add(StatusOfShips.Success);
        expectedValues.Add(StatusOfShips.Success);

        shipStatus = new Route(environments, ships).ShipHandling();

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