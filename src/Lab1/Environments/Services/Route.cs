using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Route
{
    private IList<IEnvironment> _environments;
    private IList<ISpaceship> _ships;
    private List<StatusOfShips> _shipStatus = new List<StatusOfShips>();

    public Route(IList<IEnvironment> environments, IList<ISpaceship> ships)
    {
        _environments = environments;
        _ships = ships;
    }

    public IList<StatusOfShips> ShipHandling()
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
                    _shipStatus.Add(StatusOfShips.LossOfShip);

                    continue;
                }

                if (!ship.Deflector.IsPhotonDeflectorWorking() && environment.IsObstaclesKillStaff())
                {
                    _shipStatus.Add(StatusOfShips.CrewDeaths);

                    continue;
                }
                else
                {
                    if (environment.IsTheShipWasAbleToRemainInService())
                    {
                        _shipStatus.Add(StatusOfShips.Success);

                        continue;
                    }
                    else
                    {
                        _shipStatus.Add(StatusOfShips.DestructionOfTheShip);

                        continue;
                    }
                }
            }
        }

        return _shipStatus;
    }
}