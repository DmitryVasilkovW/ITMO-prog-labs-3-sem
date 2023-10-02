namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class Asteroid : Entities.IObstacles
{
    private string _damageType;

    public Asteroid()
    {
        _damageType = "Asteroid";
    }

    public string DamageType
    {
        get { return _damageType; }
    }

    public void Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship != null && ship.IsDeflectorWorking)
        {
            ship.Deflector.AsteroidDamage();
        }
    }
}