namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

public abstract class Deflectors
{
    private int _deflectorconditionlevel;
    private IPhotonicDeflectors _photonicDeflector;
    private bool _isaPhotonDeflectorInstalled;
    private bool _isDeflectorWorking;

    protected Deflectors(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _deflectorconditionlevel = 7340;
        _isaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = false;
    }

    public bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public bool IsDeflectorWorking()
    {
        if (_deflectorconditionlevel < 0)
        {
            _isDeflectorWorking = false;
        }

        return _isDeflectorWorking;
    }

    public abstract void AsteroidDamage();

    public abstract void MeteoriteDamage();

    public abstract void SpaceWhaleDamage();

    public void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }

    public abstract void SavingStatusOfTheDeflector(string damagetype);

    protected void PhotonDeflectorInstallation(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = true;
    }
}