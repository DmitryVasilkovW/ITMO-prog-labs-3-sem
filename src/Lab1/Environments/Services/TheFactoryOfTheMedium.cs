using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class TheFactoryOfTheMedium
{
    private string _environment;
    private int _length;
    private int _countOfObstracles;
    private Spaceship.Entities.Spaceship _ship;

    public TheFactoryOfTheMedium(string environment, Spaceship.Entities.Spaceship ship, int length, int countOfObstracles)
    {
        _countOfObstracles = countOfObstracles;
        _length = length;
        _ship = ship;
        _environment = environment;
    }

    public Entities.Environment Create()
    {
        switch (_environment)
        {
            case "NormalSpace":
                return new NormalSpace(_length, _countOfObstracles, _ship);

            case "HighDensitySpaceNebulae":
                return new HighDensitySpaceNebulae(_length, _countOfObstracles, _ship);

            case "NitrinoParticleNebulae":
                return new NitrinoParticleNebulae(_length, _countOfObstracles, _ship);

            default:
                throw new ArgumentException("Invalid environment name.");
        }
    }
}