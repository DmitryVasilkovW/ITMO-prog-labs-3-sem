using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class DeflectorSlot : Entities.Deflectors
{
    private IPhotonicDeflectors _photonicDeflector;

    public DeflectorSlot(IPhotonicDeflectors photonicDeflector)
        : base(photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
    }

    public override int AsteroidDamage()
    {
        return 0;
    }

    public override int MeteoriteDamage()
    {
        return 0;
    }

    public override int SpaceWhaleDamage()
    {
        return 0;
    }

    public override void SavingStatusOfTheDeflector(string damagetype)
    {
    }
}