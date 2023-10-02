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

    public override void AsteroidDamage()
    {
    }

    public override void MeteoriteDamage()
    {
    }

    public override void SpaceWhaleDamage()
    {
    }

    public override void SavingStatusOfTheDeflector(string damagetype)
    {
    }
}