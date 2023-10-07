using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class Deflectors
{
    private IPhotonicDeflectors _photonicDeflector;
    private bool _isaPhotonDeflectorInstalled;

    protected Deflectors(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = true;
    }

    protected Deflectors()
    {
        _photonicDeflector = new PhotonDeflectorSlot();
        _isaPhotonDeflectorInstalled = false;
    }

    public virtual bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public abstract bool IsDeflectorWorking();

    public abstract void AsteroidDamage();

    public abstract bool IsPhotonDeflectorWorking();

    public abstract void MeteoriteDamage();

    public abstract void SpaceWhaleDamage();

    public virtual void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }

    public abstract void SavingStatusOfTheDeflector(string damagetype);

    public virtual void PhotonDeflectorInstallation(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = true;
    }
}