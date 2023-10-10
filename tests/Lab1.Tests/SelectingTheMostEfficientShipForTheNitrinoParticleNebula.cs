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
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class SelectingTheMostEfficientShipForTheNitrinoParticleNebula : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetShips
    {
        get { yield return new object[] { new SlowMovingShuttle(), new Vaklas(false) }; }
    }

    public static bool ResultsVerification(ISpaceship ship)
    {
        if (ship is Vaklas)
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
    [MemberData(nameof(GetShips), MemberType = typeof(SelectingTheMostEfficientShipForTheNitrinoParticleNebula))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        ISpaceship ship;
        IList<IEnvironment> environments = new List<Environment>();
        IList<INitrinoParticleNebulae> spacewhales = new List<INitrinoParticleNebulae>();
        const int length = 1;
        const int otherTaxes = 1;
        const int excises = 2;
        const int processingAndDelivery = 3;
        const int oilCompanyIncome = 4;
        const int gasStationRevenues = 5;
        const int mineralExtractionTax = 6;
        const int costOfGravitonMatterProduction = 7;
        const int costOfProductionOfActivePlasma = 8;

        var firstenvironment = new NitrinoParticleNebulae(length, spacewhales);

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