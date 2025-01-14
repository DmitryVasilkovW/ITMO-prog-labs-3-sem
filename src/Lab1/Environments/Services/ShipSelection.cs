using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class ShipSelection
{
    private IList<ISpaceship> _ships = new List<ISpaceship>();
    private FuelExchange _fuelExchange;
    private IList<IEnvironment> _environments;
    private List<List<int>> _pricesAndIndices = new List<List<int>>();
    private List<int> _canFly = new List<int>();
    private int _length;

    public ShipSelection(IList<ISpaceship> ships, FuelExchange fuelExchange, IList<IEnvironment> environments, int length)
    {
        _ships = ships;
        _fuelExchange = fuelExchange;
        _environments = environments;
        _length = length;

        int countOfShips = ships.Count;

        while (countOfShips-- != 0)
        {
            _canFly.Add(1);
        }
    }

    public ISpaceship Select()
    {
        SelectionOfShipsThatCanEnterTheEnvironment();
        FuelPriceCalculation();
        Sort();

        return _ships[SelectIndex()];
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
        int shipindex = -1;

        for (int i = 0; i < _ships.Count; i++)
        {
            shipindex++;
            for (int j = shipindex; j < _environments.Count; j += _ships.Count)
            {
                if (!_environments[j].IsCanEnterTheEnvironment(_ships[i]))
                {
                    _canFly[i] = 0;
                }
            }
        }
    }

    private void FuelPriceCalculation()
    {
        int indexOfShip = 0;

        for (int i = 0; i < _ships.Count; i++)
        {
            int price = _ships[i].Fuelreserve % _length;
            price *= _fuelExchange.ActivePlasmaPrice;

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