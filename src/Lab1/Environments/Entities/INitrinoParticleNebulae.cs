using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;

public interface INitrinoParticleNebulae
{
    void Damage(ISpaceship ship, AdditionalSafetyDevices device);
}