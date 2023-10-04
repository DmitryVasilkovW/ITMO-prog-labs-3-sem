using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class ShipSelection
{
    private IList<Spaceship.Entities.Spaceship> _shipes = new List<Spaceship.Entities.Spaceship>();
    private FuelExchange _fuelExchange;
    private Entities.Environment _environment;
    private List<List<int>> _pricesAndIndices = new List<List<int>>();
    private List<int> _canFly = new List<int>();

    public ShipSelection(IList<Spaceship.Entities.Spaceship> shipes, FuelExchange fuelExchange, Entities.Environment environment)
    {
        _shipes = shipes;
        _fuelExchange = fuelExchange;
        _environment = environment;

        int countOfShips = shipes.Count;

        while (countOfShips-- != 0)
        {
            _canFly.Add(1);
        }
    }

    public Spaceship.Entities.Spaceship Select()
    {
        SelectionOfShipsThatCanEnterTheEnvironment();
        FuelPriceCalculation();
        Sort();

        return _shipes[SelectIndex()];
    }

    private int SelectIndex()
    {
        foreach (List<int> pricesAndIndices in _pricesAndIndices)
        {
            if (_canFly[pricesAndIndices[1]] == 1)
            {
                return pricesAndIndices[1];
            }
        }

        return _pricesAndIndices[_pricesAndIndices.Count - 1][1];
    }

    private void SelectionOfShipsThatCanEnterTheEnvironment()
    {
        for (int i = 0; i < _shipes.Count; i++)
        {
            if (!_environment.IsCanEnterTheEnvironment())
            {
                _canFly[i] = 0;
            }
        }
    }

    private void FuelPriceCalculation()
    {
        int indexOfShip = 0;

        for (int i = 0; i < _shipes.Count; i++)
        {
            int price = _environment.Length / _shipes[i].Speed;

            _pricesAndIndices.Add(new List<int>() { price, indexOfShip });

            indexOfShip++;
        }
    }

    private void Sort()
    {
        for (int i = 1; i < _pricesAndIndices.Count; i++)
        {
            List<int> key = _pricesAndIndices[i];
            int j = i - 1;

            while (j >= 0 && _pricesAndIndices[j][0] > key[0])
            {
                _pricesAndIndices[j + 1] = _pricesAndIndices[j];
                j--;
            }

            _pricesAndIndices[j + 1] = key;
        }
    }
}