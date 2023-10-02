namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Meteorites : Entities.IObstacles
{
    private string _damageType;

    public Meteorites()
    {
        _damageType = "Meteorit";
    }

    public string DamageType
    {
        get { return _damageType; }
    }

    public void Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship != null && ship.IsDeflectorWorking)
        {
            ship.Deflector.MeteoriteDamage();
        }
    }
}