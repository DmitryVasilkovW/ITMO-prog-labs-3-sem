using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class DeflectorSlot : Entities.Deflectors
{
    private IPhotonicDeflectors _photonicDeflector;
    private bool _isaPhotonDeflectorInstalled;

    public DeflectorSlot(IPhotonicDeflectors photonicDeflector)
        : base(photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = false;
    }

    public override bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public override bool IsDeflectorWorking()
    {
        return false;
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