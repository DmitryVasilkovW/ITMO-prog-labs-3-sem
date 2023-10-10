using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class VaklasAugurAndMeredianVsCosmoWhaleInTheNitrinoParticleNebula : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetShips
    {
        get { yield return new object[] { new Vaklas(false), new Augur(false), new Meredian(false) }; }
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
    [MemberData(nameof(GetShips), MemberType = typeof(VaklasAugurAndMeredianVsCosmoWhaleInTheNitrinoParticleNebula))]
    public void ShipsAndEnvironments(ISpaceship firstShip, ISpaceship secondShip, ISpaceship thirdship)
    {
        IList<ISpaceship> ships = new List<ISpaceship>();
        IList<StatusOfShips> shipStatus;
        IList<StatusOfShips> expectedValues = new List<StatusOfShips>();
        var environments = new List<IEnvironment>();
        IList<INitrinoParticleNebulae> spacewhiles = new List<INitrinoParticleNebulae>();
        const int countofobstacles = 3;
        const int length = 1;

        for (int i = 0; i < countofobstacles; i++)
        {
            spacewhiles.Add(new SpaceWhale());
        }

        var firstenvironment = new NitrinoParticleNebulae(length, spacewhiles);
        var secondenvironment = new NitrinoParticleNebulae(length, spacewhiles);

        environments.Add(firstenvironment);
        environments.Add(secondenvironment);
        ships.Add(firstShip);
        ships.Add(secondShip);
        ships.Add(thirdship);
        expectedValues.Add(StatusOfShips.DestructionOfTheShip);
        expectedValues.Add(StatusOfShips.Success);
        expectedValues.Add(StatusOfShips.Success);

        shipStatus = new Route().ShipHandling(ships, environments);

        Assert.True(ResultsVerification(shipStatus, expectedValues));
    }
}