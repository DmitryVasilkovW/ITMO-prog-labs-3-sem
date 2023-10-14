using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class SpaceWhale : IObstacle, IHullDamage, INitrinoParticleNebulae
{
    public void Damage(ISpaceship ship)
    {
        ship.ProtectionFromObstacles(this);
    }
}