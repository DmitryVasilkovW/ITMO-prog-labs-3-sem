using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class Deflectors
{
    private IPhotonicDeflectors _photonicDeflector;

    protected Deflectors(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        IsaPhotonDeflectorInstalled = true;
    }

    protected Deflectors()
    {
        _photonicDeflector = new PhotonDeflectorSlot();
        IsaPhotonDeflectorInstalled = false;
    }

    public virtual bool IsaPhotonDeflectorInstalled { get; }

    public abstract bool IsDeflectorWorking();

    public abstract void AsteroidDamage();

    public abstract bool IsPhotonDeflectorWorking();

    public abstract void MeteoriteDamage();

    public abstract void SpaceWhaleDamage();

    public virtual void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled) _photonicDeflector.IsPhotonicDeflectorBroken();
    }

    public abstract void SavingStatusOfTheDeflector(AdditionalSafetyDevices device);
}