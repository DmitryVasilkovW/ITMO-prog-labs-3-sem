using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Route
{
    private Spaceship.Entities.Spaceship _ship;
    private IList<Entities.Environment> _environment;
    private IList<Spaceship.Entities.Spaceship> _spaceShips;
    private int _routeLength;

    public Route(Spaceship.Entities.Spaceship spaceship, int routeLength, IList<Entities.Environment> environment, IList<Spaceship.Entities.Spaceship> spaceShips)
    {
        _environment = environment;
        _spaceShips = spaceShips;
        _ship = spaceship;
        _routeLength = routeLength;
    }
}