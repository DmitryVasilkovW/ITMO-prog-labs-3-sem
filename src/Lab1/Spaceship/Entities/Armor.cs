namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class Armor
{
    private int _armorconditionlevel;
    private bool _isArmorWorking;

    protected Armor()
    {
        _armorconditionlevel = 1000;
        _isArmorWorking = false;
    }

    public bool IsArmorWorking()
    {
        if (_armorconditionlevel < 0)
        {
            _isArmorWorking = false;
        }

        return _isArmorWorking;
    }

    public abstract void AsteroidDamage();

    public abstract void MeteoriteDamage();

    public abstract void SpaceWhaleDamage();

    public abstract void SavingStatusOfTheArmor(string damagetype);
}