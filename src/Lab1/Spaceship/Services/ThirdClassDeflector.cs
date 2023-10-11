using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class ThirdClassDeflector : Deflectors
{
    private const int TakingAsteroidamage = 100;
    private const int TakingMeteoritedamage = 334;
    private const int TakingSpacewhaledamage = 7340;
    private const int InitialDeflectorconditionlevel = 7340;

    private int _deflectorconditionlevel;
    private bool _isDeflectorWorking;
    private IPhotonicDeflectors _photonicDeflector;

    public ThirdClassDeflector(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _deflectorconditionlevel = InitialDeflectorconditionlevel;
        IsaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public ThirdClassDeflector()
    {
        _photonicDeflector = new PhotonDeflectorSlot();
        _deflectorconditionlevel = InitialDeflectorconditionlevel;
        IsaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public override bool IsaPhotonDeflectorInstalled { get; }

    public override bool IsPhotonDeflectorWorking()
    {
        if (IsaPhotonDeflectorInstalled && !_photonicDeflector.IsPhotonicDeflectorBroken())
        {
            return true;
        }

        return false;
    }

    public override bool IsWorking()
    {
        if (_deflectorconditionlevel < 0)
        {
            _isDeflectorWorking = false;
        }

        return _isDeflectorWorking;
    }

    public override void AsteroidDamage()
    {
        _deflectorconditionlevel -= TakingAsteroidamage;
        IsWorking();
    }

    public override void MeteoriteDamage()
    {
        _deflectorconditionlevel -= TakingMeteoritedamage;
        IsWorking();
    }

    public override void SpaceWhaleDamage()
    {
        _deflectorconditionlevel -= TakingSpacewhaledamage;
        IsWorking();
    }

    public override void SavingStatusOfTheDeflector(AdditionalSafetyDevices device)
    {
        if (device is ISpaceWhaleDefense)
        {
            _deflectorconditionlevel += TakingSpacewhaledamage;
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