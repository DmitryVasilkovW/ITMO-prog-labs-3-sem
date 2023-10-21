using System;
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
using Itmo.ObjectOrientedProgramming.Lab2.MyException;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class PersonalComputer : ICloneable
{
    public PersonalComputer(
        object corpus,
        Processor? processor,
        CPUCoolingSystem? cpuCoolingSystem,
        HardDrive? hardDrive,
        Motherboard? motherboard,
        PowerSupply? powerSupply,
        IList<Ram>? ram,
        SSDDrive? ssdDrive,
        VideoCard? videoCard)
    {
        Corpus = (Corpus?)corpus;
        Processor = processor;
        CPUCoolingSystem = cpuCoolingSystem;
        HardDrive = hardDrive;
        Motherboard = motherboard;
        PowerSupply = powerSupply;
        Ram = ram;
        SsdDrive = ssdDrive;
        VideoCard = videoCard;
    }

    public Corpus? Corpus { get; private set; }
    public Processor? Processor { get; private set; }
    public CPUCoolingSystem? CPUCoolingSystem { get; private set; }
    public HardDrive? HardDrive { get; private set; }
    public Motherboard? Motherboard { get;  private set; }
    public PowerSupply? PowerSupply { get; private set; }
    public IList<Ram>? Ram { get; private set; }
    public SSDDrive? SsdDrive { get; private set; }
    public VideoCard? VideoCard { get; private set; }

    public object Clone()
    {
        if (Corpus is not null)
        {
            IList<Ram> newlistofram = new List<Ram>();
            if (Ram is not null)
            {
                foreach (Ram ram in Ram)
                {
                    newlistofram.Add((Ram)ram.Clone());
                }
            }

            if (Processor is not null
                && CPUCoolingSystem is not null
                && HardDrive is not null
                && Motherboard is not null
                && PowerSupply is not null
                && SsdDrive is not null
                && VideoCard is not null)
            {
                return new PersonalComputer(
                    Corpus.Clone(),
                    (Processor?)Processor.Clone(),
                    (CPUCoolingSystem?)CPUCoolingSystem.Clone(),
                    (HardDrive?)HardDrive.Clone(),
                    (Motherboard?)Motherboard.Clone(),
                    (PowerSupply?)PowerSupply.Clone(),
                    newlistofram,
                    (SSDDrive?)SsdDrive.Clone(),
                    (VideoCard?)VideoCard.Clone());
            }
        }

        throw new ThePassedArgumentIsNullException();
    }

    public PersonalComputer SetCorpus(Corpus? newCorpus)
    {
        var clone = (PersonalComputer)Clone();

        clone.Corpus = newCorpus;

        return clone;
    }

    public PersonalComputer SetProcessor(Processor? newProcessor)
    {
         var clone = (PersonalComputer)Clone();

         clone.Processor = newProcessor;

         return clone;
    }

    public PersonalComputer SetCPUCoolingSystem(CPUCoolingSystem? newCPUCoolingSystem)
    {
        var clone = (PersonalComputer)Clone();

        clone.CPUCoolingSystem = newCPUCoolingSystem;

        return clone;
    }

    public PersonalComputer SetHardDrive(HardDrive? newHardDrive)
    {
        var clone = (PersonalComputer)Clone();

        clone.HardDrive = newHardDrive;

        return clone;
    }

    public PersonalComputer SetHardDrive(Motherboard? newMotherboard)
    {
        var clone = (PersonalComputer)Clone();

        clone.Motherboard = newMotherboard;

        return clone;
    }

    public PersonalComputer SetHardDrive(PowerSupply? newPowerSupply)
    {
        var clone = (PersonalComputer)Clone();

        clone.PowerSupply = newPowerSupply;

        return clone;
    }

    public PersonalComputer SetHardDrive(IList<Ram>? newlistofram)
    {
        var clone = (PersonalComputer)Clone();

        clone.Ram = newlistofram;

        return clone;
    }

    public PersonalComputer SetSsdDrive(SSDDrive? newSsdDrive)
    {
        var clone = (PersonalComputer)Clone();

        clone.SsdDrive = newSsdDrive;

        return clone;
    }

    public PersonalComputer SetSsdDrive(VideoCard? newVideoCard)
    {
        var clone = (PersonalComputer)Clone();

        clone.VideoCard = newVideoCard;

        return clone;
    }
}