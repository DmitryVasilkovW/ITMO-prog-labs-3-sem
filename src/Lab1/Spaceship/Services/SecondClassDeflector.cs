using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class SecondClassDeflector : Deflectors
{
    private const int Asteroidamage = 734;
    private const int Meteoritedamage = 2447;
    private const int Spacewhaledamage = 8000;
    private const int InitialDeflectorconditionlevel = 7340;

    private int _deflectorconditionlevel;
    private bool _isaPhotonDeflectorInstalled;
    private bool _isDeflectorWorking;
    private IPhotonicDeflectors _photonicDeflector;

    public SecondClassDeflector(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _deflectorconditionlevel = InitialDeflectorconditionlevel;
        _isaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public SecondClassDeflector()
    {
        _photonicDeflector = new PhotonDeflectorSlot();
        _deflectorconditionlevel = InitialDeflectorconditionlevel;
        _isaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public override bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public override bool IsPhotonDeflectorWorking()
    {
        if (_isaPhotonDeflectorInstalled && !_photonicDeflector.IsPhotonicDeflectorBroken())
        {
            return true;
        }

        return false;
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

    public override void SavingStatusOfTheDeflector(AdditionalSafetyDevices device)
    {
        if (device is ISpaceWhaleDefense)
        {
            _deflectorconditionlevel += Spacewhaledamage;
        }
    }

    public override void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }
}