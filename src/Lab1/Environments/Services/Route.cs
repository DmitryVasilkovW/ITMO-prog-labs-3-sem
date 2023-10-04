using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Route
{
    private IList<ValuesForTheEnvironment> _environments;
    private IList<Spaceship.Entities.Spaceship> _ships;
    private List<string> _shipStatus = new List<string>();
    private int _routeLength;
    private string _successStatusForTheShip;
    private string _statusLosingAShip;
    private string _statusShipDestruction;
    private string _statusCrewDeath;

    public Route(int routeLength, IList<ValuesForTheEnvironment> environments, IList<Spaceship.Entities.Spaceship> ships)
    {
        _environments = environments;
        _ships = ships;
        _routeLength = routeLength;
        _successStatusForTheShip = "Success";
        _statusLosingAShip = "Loss of ship";
        _statusShipDestruction = "Destruction of the ship";
        _statusCrewDeath = "Crew deaths";

        int countOfShips = ships.Count;

        while (countOfShips-- != 0)
        {
            _shipStatus.Add(" ");
        }
    }

    public void ShipHandling()
    {
        int indexForShips = 0;

        foreach (ValuesForTheEnvironment values in _environments)
        {
            foreach (Spaceship.Entities.Spaceship ship in _ships)
            {
                Environment environment = new TheFactoryOfTheEnvironment(
                        values.Environment,
                        values.Ship,
                        values.Length,
                        values.CountOfFirstTypeObstracles,
                        values.CountOfSecondTypeObstracles).Create();

                if (!environment.IsCanEnterTheEnvironment())
                {
                    _shipStatus[indexForShips] = _statusLosingAShip;

                    indexForShips++;
                    continue;
                }

                if (!ship.Deflector.IsaPhotonDeflectorInstalled)
                {
                    _shipStatus[indexForShips] = _statusCrewDeath;

                    indexForShips++;
                    continue;
                }
                else
                {
                    if (environment.IsTheShipWasAbleToRemainInService())
                    {
                        _shipStatus[indexForShips] = _successStatusForTheShip;

                        indexForShips++;
                        continue;
                    }
                    else
                    {
                        _shipStatus[indexForShips] = _statusShipDestruction;

                        indexForShips++;
                        continue;
                    }
                }
            }
        }
    }
}