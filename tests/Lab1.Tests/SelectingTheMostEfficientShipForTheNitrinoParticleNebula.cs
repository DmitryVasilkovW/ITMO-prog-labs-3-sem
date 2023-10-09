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
        IList<IList<IObstacle>> obstacles = new List<IList<IObstacle>>();
        IList<IObstacle> fleshes = new List<IObstacle>();
        const int length = 1;
        const int otherTaxes = 1;
        const int excises = 2;
        const int processingAndDelivery = 3;
        const int oilCompanyIncome = 4;
        const int gasStationRevenues = 5;
        const int mineralExtractionTax = 6;
        const int costOfGravitonMatterProduction = 7;
        const int costOfProductionOfActivePlasma = 8;

        obstacles.Add(fleshes);

        var firstenvironment = new NitrinoParticleNebulae(length, obstacles, firstShip);
        var secondenvironment = new NitrinoParticleNebulae(length, obstacles, secondShip);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);

        ship = new Environments.Services.ShipSelection(
            ships,
            new FuelExchange(otherTaxes, excises, processingAndDelivery, oilCompanyIncome, gasStationRevenues, mineralExtractionTax, costOfGravitonMatterProduction, costOfProductionOfActivePlasma),
            environments,
            length).Select();

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