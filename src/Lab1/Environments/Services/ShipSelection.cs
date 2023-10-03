using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class ShipSelection
{
    private IList<Spaceship.Entities.Spaceship> _shipes;
    private FuelExchange _fuelExchange;
    private List<List<int>> _array = new List<List<int>>();
    private List<int> _canFly = new List<int>();

    public ShipSelection(IList<Spaceship.Entities.Spaceship> shipes, FuelExchange fuelExchange)
    {
        _shipes = shipes;
        _fuelExchange = fuelExchange;

        int countOfShips = shipes.Count;

        while (countOfShips-- != 0)
        {
            _canFly.Add(1);
        }
    }

    public Spaceship.Entities.Spaceship Select()
    {
        return _shipes[0];
    }

    private void FuelPriceCalculation()
    {
    }
}