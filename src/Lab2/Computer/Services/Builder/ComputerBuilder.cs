using System.Collections.Generic;
using System.Diagnostics;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public class ComputerBuilder :
    IComputerBuilder,
    IWithCase,
    IWithMotherboard,
    IWithCPU,
    IWithCPUCoolingSystem,
    IWithRAM,
    IWithHardDrive,
    IWithSSDDrive,
    IWithVideoCard,
    IWithPowerSupply
{
    private Corpus? _corpus;
    private Processor? _processor;
    private CPUCoolingSystem? _cpuCoolingSystem;
    private HardDrive? _hardDrive;
    private Motherboard? _motherboard;
    private PowerSupply? _powerSupply;
    private IList<Ram>? _ram;
    private SSDDrive? _ssdDrive;
    private VideoCard? _videoCard;

    public PersonalComputer Build()
    {
        Debug.Assert(_corpus is not null, nameof(_corpus) + " != null");
        return new PersonalComputer(
            _corpus,
            _processor,
            _cpuCoolingSystem,
            _hardDrive,
            _motherboard,
            _powerSupply,
            _ram,
            _ssdDrive,
            _videoCard);
    }

    public IWithMotherboard WithCase(Corpus corpus)
    {
        _corpus = corpus;

        return this;
    }

    public IWithCPU WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public IWithCPUCoolingSystem WithCPU(Processor processor)
    {
        _processor = processor;

        return this;
    }

    public IWithRAM WithCPUCoolingSystem(CPUCoolingSystem cpuCoolingSystem)
    {
        _cpuCoolingSystem = cpuCoolingSystem;

        return this;
    }

    public IWithHardDrive WithRAM(IList<Ram> ram)
    {
        _ram = ram;

        return this;
    }

    public IWithSSDDrive WithHardDrive(HardDrive hardDrive)
    {
        _hardDrive = hardDrive;

        return this;
    }

    public IWithVideoCard WithSSDDrive(SSDDrive ssdDrive)
    {
        _ssdDrive = ssdDrive;

        return this;
    }

    public IWithPowerSupply WithVideoCard(VideoCard videoCard)
    {
        _videoCard = videoCard;

        return this;
    }

    public IComputerBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;

        return this;
    }
}