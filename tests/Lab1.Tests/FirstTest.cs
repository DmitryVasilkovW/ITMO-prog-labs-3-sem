using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    public static bool IsOddNumber(IList<string> shipStatus, IList<string> expectedValues, int a)
    {
        for (int i = a; i < shipStatus.Count; i++)
        {
            for (int j = 0; j < expectedValues.Count; j++)
            {
                if (shipStatus[i] != expectedValues[j])
                    return false;
            }
        }

        return true;
    }

    [Theory]
    [InlineData(0)]
    public void AllNumbersAreOddWithInlineData(int a)
    {
        IList<Spaceship.Entities.Spaceship> ships = new List<Spaceship.Entities.Spaceship>();
        IList<string> shipStatus;
        IList<string> expectedValues = new List<string>();

        IList<ValuesForTheEnvironment> environments = new List<ValuesForTheEnvironment>();

        var firstValue = new ValuesForTheEnvironment("HighDensitySpaceNebulae", new SlowMovingShuttle(), 239, 10, 0);
        environments.Add(firstValue);
        var secondValue = new ValuesForTheEnvironment("HighDensitySpaceNebulae", new Augur(false), 239, 10, 0);
        environments.Add(secondValue);

        ships.Add(new SlowMovingShuttle());
        ships.Add(new Augur(false));
        expectedValues.Add("Destruction of the ship");
        expectedValues.Add("Destruction of the ship");

        shipStatus = new Route(239, environments, ships).ShipHandling();

        Assert.True(IsOddNumber(shipStatus, expectedValues, a));
    }
}