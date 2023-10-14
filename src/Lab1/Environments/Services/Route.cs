using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;
using IEnvironment = Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities.IEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Route
{
    private List<StatusOfShips> _shipStatus = new List<StatusOfShips>();

    public IList<StatusOfShips> ShipHandling(IList<ISpaceship> ships, IList<IEnvironment> environments)
    {
        foreach (ISpaceship ship in ships)
        {
            for (int i = 0; i < environments.Count; i += ships.Count)
            {
                IEnvironment environment = environments[i];

                if (!environment.IsCanEnterTheEnvironment(ship))
                {
                    _shipStatus.Add(StatusOfShips.LossOfShip);

                    continue;
                }

                if (!ship.Deflector.IsPhotonDeflectorWorking() && environment.IsObstaclesKillStaff())
                {
                    _shipStatus.Add(StatusOfShips.CrewDeaths);
                }
                else
                {
                    if (environment.IsTheShipWasAbleToRemainInService(ship))
                    {
                        _shipStatus.Add(StatusOfShips.Success);
                    }
                    else
                    {
                        _shipStatus.Add(StatusOfShips.DestructionOfTheShip);
                    }
                }
            }
        }

        return _shipStatus;
    }
}