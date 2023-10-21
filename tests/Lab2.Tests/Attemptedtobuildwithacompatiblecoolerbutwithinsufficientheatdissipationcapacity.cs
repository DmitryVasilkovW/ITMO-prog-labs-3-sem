using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.MyException;
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
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Check;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Repository;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Attemptedtobuildwithacompatiblecoolerbutwithinsufficientheatdissipationcapacity : IEnumerable<object[]>
{
    public static IEnumerable<object[]> GetShips
    {
        get
        {
            yield return new object[]
        {
            "Cougar Duoface",
            "AMD Ryzen 5 5600X OEM",
            "DARK ROCK PRO 4",
            "WD Blue",
            "GIGABYTE B550 AORUS ELITE V2",
            "AeroCool VX PLUS 500W",
            "Kingston FURY Beast Black",
            "Kingston A400",
            "GeForce RTX 3060 Ti Dual",
        };
        }
    }

    public static bool ResultsVerification(CheckStatus status, CheckStatus expectedValue)
    {
        if (status == expectedValue)
        {
            return true;
        }

        return false;
    }

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
        throw new IncorrectNumberOfArgumentsException();
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    [Theory]
    [MemberData(nameof(GetShips), MemberType = typeof(Attemptedtobuildwithacompatiblecoolerbutwithinsufficientheatdissipationcapacity))]
    public void ComputerAssembly(
        string nameofcorpus,
        string nameforCPU,
        string nameforcooling,
        string nameforhdd,
        string nameformotherboard,
        string nameforPowerSupply,
        string nameforram,
        string nameforssd,
        string nameforcard)
    {
        var repository = new Repository();
        repository.InitDatabase();
        var corpus = (Corpus)repository.GetPart(nameofcorpus);
        var cpu = (Processor)repository.GetPart(nameforCPU);
        var cooling = (CPUCoolingSystem)repository.GetPart(nameforcooling);
        var hdd = (HardDrive)repository.GetPart(nameforhdd);
        var motherboard = (Motherboard)repository.GetPart(nameformotherboard);
        var powerSupply = (PowerSupply)repository.GetPart(nameforPowerSupply);
        var ram = (Ram)repository.GetPart(nameforram);
        var ssd = (SSDDrive)repository.GetPart(nameforssd);
        var videocard = (VideoCard)repository.GetPart(nameforcard);

        IList<Ram> listofram = new List<Ram>()
        {
            ram,
        };

        PersonalComputer compute = new ComputerBuilder().
            WithCase(corpus).
            WithMotherboard(motherboard).
            WithCPU(cpu).
            WithCPUCoolingSystem(cooling).
            WithRAM(listofram).
            WithHardDrive(hdd).WithSSDDrive(ssd).
            WithVideoCard(videocard).
            WithPowerSupply(powerSupply).Build();

        CheckStatus status = new Verification().CheckingThatTheComponentsHaveBeenInstalledCorrectly(compute);
        CheckStatus expectedValue = CheckStatus.Denialofwarrantyduetothefactthatthecoolingsystemisnotcapableofcoolingthisprocessor;

        Assert.True(ResultsVerification(status, expectedValue));
    }
}