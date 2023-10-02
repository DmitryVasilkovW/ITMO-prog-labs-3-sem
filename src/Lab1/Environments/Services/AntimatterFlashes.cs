namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.Services;

public class AntimatterFlashes : Entities.IObstacles
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

    public void Damage(Spaceship.Entities.Spaceship ship)
    {
        if (ship.IsDeflectorWorking && ship.Deflector.IsaPhotonDeflectorInstalled)
        {
            ship.Deflector.AntimatterFlashesDamage();
        }
        else
        {
            ship.StaffAssault();
        }
    }
}