using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class SecondClassDeflector : Deflectors
{
    private int _deflectorconditionlevel;
    private bool _isaPhotonDeflectorInstalled;
    private bool _isDeflectorWorking;
    private IPhotonicDeflectors _photonicDeflector;

    public SecondClassDeflector(IPhotonicDeflectors photonicDeflector)
        : base(photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _deflectorconditionlevel = 7340;
        _isaPhotonDeflectorInstalled = false;
        _isDeflectorWorking = true;
    }

    public new bool IsaPhotonDeflectorInstalled
    {
        get { return _isaPhotonDeflectorInstalled; }
    }

    public new bool IsDeflectorWorking()
    {
        if (_deflectorconditionlevel < 0)
        {
            _isDeflectorWorking = false;
        }

        return _isDeflectorWorking;
    }

    public override int AsteroidDamage()
    {
        return _deflectorconditionlevel -= 734;
    }

    public override int MeteoriteDamage()
    {
        return _deflectorconditionlevel -= 2447;
    }

    public override int SpaceWhaleDamage()
    {
        return _deflectorconditionlevel -= 8000;
    }

    public override void SavingStatusOfTheDeflector(string damagetype)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _deflectorconditionlevel += 8000;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _deflectorconditionlevel += 2447;
        }
        else
        {
            _deflectorconditionlevel += 734;
        }
    }

    public new void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }

    protected new void PhotonDeflectorInstallation(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = true;
    }
}