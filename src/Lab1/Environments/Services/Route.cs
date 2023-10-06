using System;
using System.Collections.Generic;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Route
{
    private IList<ValuesForTheEnvironment> _environments;
    private IList<Spaceship.Entities.ISpaceship> _ships;
    private List<string> _shipStatus = new List<string>();
    private int _routeLength;
    private string _successStatusForTheShip;
    private string _statusLosingAShip;
    private string _statusShipDestruction;
    private string _statusCrewDeath;

    public Route(int routeLength, IList<ValuesForTheEnvironment> environments, IList<Spaceship.Entities.ISpaceship> ships)
    {
        _environments = environments;
        _ships = ships;
        _routeLength = routeLength;
        _successStatusForTheShip = "Success";
        _statusLosingAShip = "Loss of ship";
        _statusShipDestruction = "Destruction of the ship";
        _statusCrewDeath = "Crew deaths";
    }

    public IList<string> ShipHandling()
    {
        int indexForEnvironments = -1;
        foreach (Spaceship.Entities.ISpaceship ship in _ships)
        {
            indexForEnvironments++;
            for (int i = indexForEnvironments; i < _environments.Count; i += _ships.Count)
            {
                Environment environment = new TheFactoryOfTheEnvironment(
                        _environments[i].Environment,
                        _environments[i].Ship,
                        _environments[i].Length,
                        _environments[i].CountOfFirstTypeObstracles,
                        _environments[i].CountOfSecondTypeObstracles).Create();

                if (!environment.IsCanEnterTheEnvironment())
                {
                    _shipStatus.Add(_statusLosingAShip);

                    continue;
                }

                if (!ship.IsPhotonDeflectorWorking && environment.SecondTypeObstracleType.Equals("Antimatter Flash", StringComparison.Ordinal) && environment.CountOfSecondTypeObstracles > 0)
                {
                    _shipStatus.Add(_statusCrewDeath);

                    continue;
                }
                else
                {
                    if (environment.IsTheShipWasAbleToRemainInService())
                    {
                        _shipStatus.Add(_successStatusForTheShip);

                        continue;
                    }
                    else
                    {
                        _shipStatus.Add(_statusShipDestruction);

                        continue;
                    }
                }
            }
        }

        return _shipStatus;
    }
}