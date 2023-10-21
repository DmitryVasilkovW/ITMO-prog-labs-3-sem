using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class PersonalComputer
{
    public PersonalComputer(
        Corpus? corpus,
        Processor? processor,
        CPUCoolingSystem? cpuCoolingSystem,
        HardDrive? hardDrive,
        Motherboard? motherboard,
        PowerSupply? powerSupply,
        IList<Ram>? ram,
        SSDDrive? ssdDrive,
        VideoCard? videoCard)
    {
        Corpus = corpus;
        Processor = processor;
        CPUCoolingSystem = cpuCoolingSystem;
        HardDrive = hardDrive;
        Motherboard = motherboard;
        PowerSupply = powerSupply;
        Ram = ram;
        SsdDrive = ssdDrive;
        VideoCard = videoCard;
    }

    public Corpus? Corpus { get; private init; }
    public Processor? Processor { get; private init; }
    public CPUCoolingSystem? CPUCoolingSystem { get; private init; }
    public HardDrive? HardDrive { get; private init; }
    public Motherboard? Motherboard { get; private init; }
    public PowerSupply? PowerSupply { get; private init; }
    public IList<Ram>? Ram { get; private init; }
    public SSDDrive? SsdDrive { get; private init; }
    public VideoCard? VideoCard { get; private init; }
}