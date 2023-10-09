using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Route
{
    private IList<IEnvironment> _environments;
    private IList<ISpaceship> _ships;
    private List<string> _shipStatus = new List<string>();
    private string _successStatusForTheShip;
    private string _statusLosingAShip;
    private string _statusShipDestruction;
    private string _statusCrewDeath;

    public Route(IList<IEnvironment> environments, IList<ISpaceship> ships)
    {
        _environments = environments;
        _ships = ships;
        _successStatusForTheShip = "Success";
        _statusLosingAShip = "Loss of ship";
        _statusShipDestruction = "Destruction of the ship";
        _statusCrewDeath = "Crew deaths";
    }

    public IList<string> ShipHandling()
    {
        int indexForEnvironments = -1;
        foreach (ISpaceship ship in _ships)
        {
            indexForEnvironments++;
            for (int i = indexForEnvironments; i < _environments.Count; i += _ships.Count)
            {
                IEnvironment environment = _environments[i];

                if (!environment.IsCanEnterTheEnvironment())
                {
                    _shipStatus.Add(_statusLosingAShip);

                    continue;
                }

                if (!ship.Deflector.IsPhotonDeflectorWorking() && environment.IsObstaclesKillStaff())
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