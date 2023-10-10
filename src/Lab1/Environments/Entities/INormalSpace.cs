using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface INormalSpace
{
    void Damage(ISpaceship ship, AdditionalSafetyDevices device);
}