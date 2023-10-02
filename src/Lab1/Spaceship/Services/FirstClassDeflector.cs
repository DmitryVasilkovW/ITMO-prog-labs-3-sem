using System;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship.Services;

public class FirstClassDeflector : Deflectors
{
    private int _deflectorconditionlevel;
    private bool _isaPhotonDeflectorInstalled;
    private bool _isDeflectorWorking;
    private IPhotonicDeflectors _photonicDeflector;

    public FirstClassDeflector(IPhotonicDeflectors photonicDeflector)
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
        return _deflectorconditionlevel -= 3670;
    }

    public override int MeteoriteDamage()
    {
        return _deflectorconditionlevel -= 7340;
    }

    public override int SpaceWhaleDamage()
    {
        return _deflectorconditionlevel -= 10000;
    }

    public new void AntimatterFlashesDamage()
    {
        if (IsaPhotonDeflectorInstalled)
        {
            _photonicDeflector.IsPhotonicDeflectorBroken();
        }
    }

    public override void SavingStatusOfTheDeflector(string damagetype)
    {
        if (damagetype.Equals("SpaceWhale", StringComparison.Ordinal))
        {
            _deflectorconditionlevel += 10000;
        }
        else if (damagetype.Equals("Meteorit", StringComparison.Ordinal))
        {
            _deflectorconditionlevel += 7340;
        }
        else
        {
            _deflectorconditionlevel += 3670;
        }
    }

    protected new void PhotonDeflectorInstallation(IPhotonicDeflectors photonicDeflector)
    {
        _photonicDeflector = photonicDeflector;
        _isaPhotonDeflectorInstalled = true;
    }
}