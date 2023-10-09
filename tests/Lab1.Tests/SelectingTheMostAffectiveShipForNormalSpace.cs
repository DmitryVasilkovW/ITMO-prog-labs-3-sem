using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SelectingTheMostAffectiveShipForNormalSpace
{
    public static bool ResultsVerification(ISpaceship ship)
    {
        if (ship is SlowMovingShuttle)
        {
            return true;
        }

        return false;
    }

    [Theory]
    [ClassData(typeof(ParameterizedTests))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        ISpaceship ship;
        IList<IEnvironment> environments = new List<IEnvironment>();
        IList<IList<IObstacle>> obstacles = new List<IList<IObstacle>>();
        IList<IObstacle> fleshes = new List<IObstacle>();
        int length = 50;
        int otherTaxes = 1;
        int excises = 2;
        int processingAndDelivery = 3;
        int oilCompanyIncome = 4;
        int gasStationRevenues = 5;
        int mineralExtractionTax = 6;
        int costOfGravitonMatterProduction = 7;
        int costOfProductionOfActivePlasma = 8;

        obstacles.Add(fleshes);

        var firstenvironment = new NormalSpace(length, obstacles, firstShip);
        var secondenvironment = new NormalSpace(length, obstacles, secondShip);

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