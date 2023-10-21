namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Check;

public enum CheckStatus
{
    None,
    ComputerAssemblyWasSuccessful,
    FailedToAssembleTheComputer,
    Disclaimerofwarrantyduetoexceedingtherecommendedconsumptionofthepowersupplyunit,
    Denialofwarrantyduetothefactthatthecoolingsystemisnotcapableofcoolingthisprocessor,
    Biosdoesnotsupporttheprocessor,
    Thecoolingsystemcannothandletheload,
    Unsupportedmemorystandard,
}