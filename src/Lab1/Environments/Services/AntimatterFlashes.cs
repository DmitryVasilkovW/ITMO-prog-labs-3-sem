using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class AntimatterFlashes : IObstacle, IPersonnelDamage, IHighDensitySpaceNebulae
{
    public void Damage(ISpaceship ship)
    {
        if (ship.Deflector.IsWorking() && ship.Deflector.IsaPhotonDeflectorInstalled)
        {
            ship.Deflector.AntimatterFlashesDamage();
        }
    }
}