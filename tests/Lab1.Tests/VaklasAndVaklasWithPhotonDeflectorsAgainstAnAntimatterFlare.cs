using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class VaklasAndVaklasWithPhotonDeflectorsAgainstAnAntimatterFlare : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetShips
    {
        get { yield return new object[] { new Vaklas(true), new Vaklas(false) }; }
    }

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

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
        throw new IncorrectNumberOfArgumentsException();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    [Theory]
    [MemberData(nameof(GetShips), MemberType = typeof(VaklasAndVaklasWithPhotonDeflectorsAgainstAnAntimatterFlare))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        IList<StatusOfShips> shipStatus;
        IList<StatusOfShips> expectedValues = new List<StatusOfShips>();
        IList<IEnvironment> environments = new List<IEnvironment>();
        IList<IHighDensitySpaceNebulae> fleshes = new List<IHighDensitySpaceNebulae>();
        const int length = 1;
        const int countofobstacles = 2;

        for (int i = 0; i < countofobstacles; i++)
        {
            fleshes.Add(new AntimatterFlashes());
        }

        var firstenvironment = new HighDensitySpaceNebulae(length, fleshes);

        environments.Add(firstenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        expectedValues.Add(StatusOfShips.Success);
        expectedValues.Add(StatusOfShips.CrewDeaths);

        shipStatus = new Route().ShipHandling(ships, environments);

        Assert.True(ResultsVerification(shipStatus, expectedValues));
    }
}