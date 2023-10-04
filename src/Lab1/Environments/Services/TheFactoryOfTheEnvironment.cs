using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class TheFactoryOfTheEnvironment
{
    private string _environment;
    private int _length;
    private int _countOfFirstTypeObstracles;
    private int _countOfSecondTypeObstracles;
    private Spaceship.Entities.Spaceship _ship;

    public TheFactoryOfTheEnvironment(string environment, Spaceship.Entities.Spaceship ship, int length, int countOfFirstTypeObstracles, int countOfSecondTypeObstracles)
    {
        _countOfFirstTypeObstracles = countOfFirstTypeObstracles;
        _countOfSecondTypeObstracles = countOfSecondTypeObstracles;
        _length = length;
        _ship = ship;
        _environment = environment;
    }

    public Entities.Environment Create()
    {
        switch (_environment)
        {
            case "NormalSpace":
                return new NormalSpace(_length, _countOfFirstTypeObstracles, _countOfSecondTypeObstracles, _ship);

            case "HighDensitySpaceNebulae":
                return new HighDensitySpaceNebulae(_length, _countOfFirstTypeObstracles, _countOfSecondTypeObstracles, _ship);

            case "NitrinoParticleNebulae":
                return new NitrinoParticleNebulae(_length, _countOfFirstTypeObstracles, _countOfSecondTypeObstracles, _ship);

            default:
                throw new ArgumentException("Invalid environment name.");
        }
    }
}