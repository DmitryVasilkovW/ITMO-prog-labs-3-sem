using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FirstTest
{
    public static bool IsOddNumber(IList<string> shipStatus, IList<string> expectedValues)
    {
        for (int i = 0; i < shipStatus.Count; i++)
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
    [ClassData(typeof(ParameterizedTests))]
    public void AllNumbersAreOddWithClassData(string firstExpectedValue, string secondExpectedValue)
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
        expectedValues.Add(firstExpectedValue);
        expectedValues.Add(secondExpectedValue);

        shipStatus = new Route(239, environments, ships).ShipHandling();

        Assert.True(IsOddNumber(shipStatus, expectedValues));
    }

    private class ParameterizedTests : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { "Destruction of the ship", "Destruction of the ship" },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}