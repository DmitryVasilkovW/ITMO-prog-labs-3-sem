using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class AntimatterFlashes : Entities.IObstacle
{
    private string _damageType;

    public AntimatterFlashes()
    {
        _damageType = "Antimatter Flash";
    }

    public string DamageType
    {
        get { return _damageType; }
    }

    public ISpaceship Damage(ISpaceship ship)
    {
        if (ship.IsDeflectorWorking && ship.Deflector.IsaPhotonDeflectorInstalled)
        {
            ship.Deflector.AntimatterFlashesDamage();
        }

        return ship;
    }
}