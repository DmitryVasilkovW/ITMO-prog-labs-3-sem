using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.RAM.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Check;

public class Verification
{
    private const int PowerSupplyLoadReserve = 200;
    private const int CoolingsystemLoadReserve = 50;
    private CheckStatus _status = CheckStatus.ComputerAssemblyWasSuccessful;

    public CheckStatus CheckingThatTheComponentsHaveBeenInstalledCorrectly(PersonalComputer computer)
    {
        if (computer.Motherboard is not null
            && computer.Motherboard.Bios is not null
            && computer.Motherboard.Bios.ListOfSupportedCPUs is not null)
        {
            _status = CheckStatus.Biosdoesnotsupporttheprocessor;

            foreach (ICPU cpu in computer.Motherboard.Bios.ListOfSupportedCPUs)
            {
                if (cpu.Name is not null && cpu.Name.Equals(computer.Processor?.Name, StringComparison.Ordinal))
                {
                    _status = CheckStatus.ComputerAssemblyWasSuccessful;
                    break;
                }
            }

            if (_status == CheckStatus.Biosdoesnotsupporttheprocessor)
            {
                return CheckStatus.Biosdoesnotsupporttheprocessor;
            }
        }

        if (computer.CPUCoolingSystem is not null
            && computer.Corpus is not null
            && computer.Corpus.MaximumCPUCoolerHeight
            < computer.CPUCoolingSystem.Dimensions.Height)
        {
            return CheckStatus.FailedToAssembleTheComputer;
        }

        if (computer.Processor is not null
            && computer.SsdDrive is not null
            && computer.HardDrive is not null
            && computer.PowerSupply is not null
            && computer.PowerSupply.PeakLoad
            + PowerSupplyLoadReserve
            < computer.HardDrive.PowerConsumption
            + computer.SsdDrive.PowerConsumption
            + computer.Processor.ConsumptionPower)
        {
            return CheckStatus.FailedToAssembleTheComputer;
        }

        if (computer.Processor is not null
            && computer.SsdDrive is not null
            && computer.HardDrive is not null
            && computer.PowerSupply is not null
            && computer.PowerSupply.PeakLoad
            < computer.HardDrive.PowerConsumption
            + computer.SsdDrive.PowerConsumption
            + computer.Processor.ConsumptionPower)
        {
            return CheckStatus.Disclaimerofwarrantyduetoexceedingtherecommendedconsumptionofthepowersupplyunit;
        }

        if (computer.Processor is not null
            && computer.VideoCard is null
            && computer.Processor.AvailabilityOfABuiltInVideoCore is false)
        {
            return CheckStatus.FailedToAssembleTheComputer;
        }

        if (computer.Motherboard is not null
            && computer.Ram is not null
            && computer.Ram.Count
            > computer.Motherboard.NumberOfTablesUnderRAM)
        {
            return CheckStatus.FailedToAssembleTheComputer;
        }

        if (computer.Ram is not null)
        {
            foreach (Ram ram in computer.Ram)
            {
                if (ram.ConnectionOption is not null && computer.Motherboard is not null)
                {
                    if (computer.Motherboard.MemoryStandard is not null && ram.ConnectionOption.Name is not null && !ram.ConnectionOption.Name.Equals(computer.Motherboard.MemoryStandard.Name, StringComparison.Ordinal))
                    {
                        _status = CheckStatus.Unsupportedmemorystandard;
                        break;
                    }
                }
            }
        }

        if (computer.Motherboard is not null && computer.Processor is not null)
        {
            if (computer.Motherboard.CPUSocket is not null
                && computer.Processor.Socket is not null
                && computer.Motherboard.CPUSocket.Name is not null
                && !computer.Motherboard.CPUSocket.Name.Equals(computer.Processor.Socket.Name, StringComparison.Ordinal))
            {
                return CheckStatus.FailedToAssembleTheComputer;
            }
        }

        if (computer.CPUCoolingSystem is not null
            && computer.Processor is not null
            && computer.Processor.HeatEmission
            > computer.CPUCoolingSystem.MaximumHeatDissipation
            + CoolingsystemLoadReserve)
        {
            return CheckStatus.Thecoolingsystemcannothandletheload;
        }

        if (computer.CPUCoolingSystem is not null
            && computer.Processor is not null
            && computer.Processor.HeatEmission
            > computer.CPUCoolingSystem.MaximumHeatDissipation)
        {
            return CheckStatus.Denialofwarrantyduetothefactthatthecoolingsystemisnotcapableofcoolingthisprocessor;
        }

        return _status;
    }
}