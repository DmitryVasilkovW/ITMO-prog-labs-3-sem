using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;
using Xunit;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SelectingTheMostEfficientShipForTheNitrinoParticleNebula
{
    public static bool ResultsVerification(Spaceship.Entities.ISpaceship ship)
    {
        if (ship is Vaklas)
        {
            return true;
        }

        return false;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(Spaceship.Entities.ISpaceship firstShip, Spaceship.Entities.ISpaceship secondShip)
    {
        IList<Spaceship.Entities.ISpaceship> ships = new List<Spaceship.Entities.ISpaceship>();
        Spaceship.Entities.ISpaceship ship;
        IList<IEnvironment> environments = new List<Environment>();
        IList<IList<IObstacle>> obstracles = new List<IList<IObstacle>>();
        IList<IObstacle> fleshes = new List<IObstacle>();
        int length = 1;

        obstracles.Add(fleshes);

        var firstenvironment = new NitrinoParticleNebulae(length, obstracles, firstShip);
        var secondenvironment = new NitrinoParticleNebulae(length, obstracles, secondShip);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);

        ship = new Environments.Services.ShipSelection(
            ships,
            new FuelExchange(2, 3, 4, 5, 6, 7, 8, 9),
            environments,
            100).Select();

        Assert.True(ResultsVerification(ship));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new SlowMovingShuttle(),
                new Vaklas(false),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}