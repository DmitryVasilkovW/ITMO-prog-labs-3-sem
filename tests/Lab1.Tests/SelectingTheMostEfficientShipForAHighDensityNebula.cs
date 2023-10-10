using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SelectingTheMostEfficientShipForAHighDensityNebula : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetShips
    {
        get { yield return new object[] { new Augur(false), new Stella(false), }; }
    }

    public static bool ResultsVerification(ISpaceship ship)
    {
        if (ship is Stella)
        {
            return true;
        }

        return false;
    }

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
        throw new IncorrectNumberOfArgumentsException();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    [Theory]
    [MemberData(nameof(GetShips), MemberType = typeof(SelectingTheMostEfficientShipForAHighDensityNebula))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        ISpaceship ship;
        IList<IEnvironment> environments = new List<IEnvironment>();
        IList<IHighDensitySpaceNebulae> fleshes = new List<IHighDensitySpaceNebulae>();
        const int length = 100;
        const int otherTaxes = 1;
        const int excises = 2;
        const int processingAndDelivery = 3;
        const int oilCompanyIncome = 4;
        const int gasStationRevenues = 5;
        const int mineralExtractionTax = 6;
        const int costOfGravitonMatterProduction = 7;
        const int costOfProductionOfActivePlasma = 8;

        var firstenvironment = new HighDensitySpaceNebulae(length, fleshes);

        environments.Add(firstenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);

        ship = new ShipSelection(
            ships,
            new FuelExchange(otherTaxes, excises, processingAndDelivery, oilCompanyIncome, gasStationRevenues, mineralExtractionTax, costOfGravitonMatterProduction, costOfProductionOfActivePlasma),
            environments,
            length).Select();

        Assert.True(ResultsVerification(ship));
    }
}