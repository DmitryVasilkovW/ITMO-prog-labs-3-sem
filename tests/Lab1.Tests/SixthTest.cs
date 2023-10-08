using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;
using Xunit;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SixthTest
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
    public void ShipsAndEnvironments(Spaceship.Entities.ISpaceship firstShip, Spaceship.Entities.ISpaceship secondShip, Environment environmentForFirstShip, Environment environmentForSecondShip)
    {
        IList<Spaceship.Entities.ISpaceship> ships = new List<Spaceship.Entities.ISpaceship>();
        Spaceship.Entities.ISpaceship ship;
        IList<Environments.Entities.IEnvironment> environments = new List<Environment>();

        environments.Add(environmentForFirstShip);
        environments.Add(environmentForSecondShip);
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
        private const int Length = 100;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new SlowMovingShuttle(),
                new Vaklas(false),
                new NitrinoParticleNebulae(Length, 0, 0, new SlowMovingShuttle()),
                new NitrinoParticleNebulae(Length, 0, 0, new Vaklas(false)),
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}