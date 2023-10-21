using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Corpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPUcoolingsystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Harddrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Motherboard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Part;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Powersupplyunit.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.SSDdrive.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Repository;

public class Repository
{
    private Database _database = new Database();

    public void AddNewPart(int id, IPartCharacteristics newtable)
    {
        _database.Addtable(id, newtable);
    }

    public void InitDatabase()
    {
        DatabaseWithComponents.GetData(_database);
    }

    public IPart GetPart(string name)
    {
        IPartCharacteristics characteristics = _database.FindByName(name);

        switch (characteristics)
        {
            case TableOfCPUCharacteristics:
                Processor cpu =
                    new CPUFactory().
                    CreatePart((TableOfCPUCharacteristics)characteristics);

                return cpu;

            case TableOfCPUCoolingSystemCharacteristics:
                CPUCoolingSystem cpuCoolingSystem =
                    new CPUCoolingSystemFactory().
                        CreatePart((TableOfCPUCoolingSystemCharacteristics)characteristics);

                return cpuCoolingSystem;

            case TableOfCaseCharacteristics:
                Corpus corpus =
                    new CaseFactory().
                        CreatePart((TableOfCaseCharacteristics)characteristics);

                return corpus;

            case TableOfHardDriveCharacteristics:
                HardDrive hardDrive =
                    new HardDriveFactory().
                        CreatePart((TableOfHardDriveCharacteristics)characteristics);

                return hardDrive;

            case TableOfSSDDriveCharacteristics:
                SSDDrive ssdDrive =
                    new SSDDriveFactory().
                        CreatePart((TableOfSSDDriveCharacteristics)characteristics);

                return ssdDrive;

            case TableOfPowerSupplyCharacteristics:
                PowerSupply powerSupply =
                    new PowerSupplyFactory().
                        CreatePart((TableOfPowerSupplyCharacteristics)characteristics);

                return powerSupply;

            case TableOfMotherboardCharacteristics:
                Motherboard motherboard =
                    new MotherboardFactory().
                        CreatePart((TableOfMotherboardCharacteristics)characteristics);

                return motherboard;

            case TableOfRAMCharacteristics:
                Ram ram =
                    new RAMFactory().
                        CreatePart((TableOfRAMCharacteristics)characteristics);

                return ram;

            case TableOfVideoCardCharacteristics:
                VideoCard videoCard =
                    new VideoCardFactory().
                        CreatePart((TableOfVideoCardCharacteristics)characteristics);

                return videoCard;
        }

        throw new AggregateException();
    }
}