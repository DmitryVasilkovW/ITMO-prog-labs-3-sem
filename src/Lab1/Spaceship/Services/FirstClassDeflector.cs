using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class FirstClassDeflector : Deflectors
{
    private const int Asteroidamage = 3670;
    private const int Meteoritedamage = 7340;
    private const int Spacewhaledamage = 10000;

    private int _deflectorconditionlevel;
    private bool _isaPhotonDeflectorInstalled;
    private bool _isDeflectorWorking;
    private IPhotonicDeflectors _photonicDeflector;

    public FirstClassDeflector(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _deflectorconditionlevel = 7340;
        _isaPhotonDeflectorInstalled = true;
        _isDeflectorWorking = true;
    }

    public FirstClassDeflector()
    {
        _photonicDeflector = new PhotonDeflectorSlot();
        _deflectorconditionlevel = 7340;
        _isaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public override bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public override bool IsDeflectorWorking()
    {
        if (_deflectorconditionlevel < 0)
        {
            _isDeflectorWorking = false;
        }

        return _isDeflectorWorking;
    }

    public override void AsteroidDamage()
    {
        _deflectorconditionlevel -= Asteroidamage;
        IsDeflectorWorking();
    }

    public override void MeteoriteDamage()
    {
        _deflectorconditionlevel -= Meteoritedamage;
        IsDeflectorWorking();
    }

    public override void SpaceWhaleDamage()
    {
        _deflectorconditionlevel -= Spacewhaledamage;
        IsDeflectorWorking();
    }

    public override bool IsPhotonDeflectorWorking()
    {
        if (_isaPhotonDeflectorInstalled && !_photonicDeflector.IsPhotonicDeflectorBroken())
        {
            return true;
        }

        return false;
    }

    public override void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }

    public override void SavingStatusOfTheDeflector(AdditionalSafetyDevices device)
    {
        if (device is ISpaceWhaleDefense)
        {
            _deflectorconditionlevel += Spacewhaledamage;
        }
    }
}