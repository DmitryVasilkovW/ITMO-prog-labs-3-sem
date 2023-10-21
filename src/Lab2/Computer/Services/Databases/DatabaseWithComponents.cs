using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Connectionoption;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.CPU.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Formfactor;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.XMPS;
using DDR4 = Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Memorystandard.DDR4;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

public static class DatabaseWithComponents
{
    private const int FirstID = 1;
    private const int SecondID = 2;
    private const int ThirdID = 3;
    private const int FourthID = 4;
    private const int FifthID = 5;
    private const int SixthID = 6;
    private const int SeventhID = 7;
    private const int EighthID = 8;
    private const int NinthID = 9;
    private const int TenthID = 10;
    private const int EleventhID = 11;
    private const int TwelfthID = 12;
    private const int ThirteenthID = 13;
    private const int FourteenthID = 14;
    private const int FifteenthID = 15;
    private const int SixteenthID = 16;
    private const int SeventeenthID = 17;
    private const int EighteenthID = 18;

    private const int MaximumCPUCoolerHeightforfirstcase = 190;
    private const int MaximumCPUCoolerHeightforsecondcase = 250;

    private const string Nameoffirstcorpus = "Cougar Duoface";
    private const string Nameofsecondcorpus = "ARDOR GAMING Rare";

    private const int MaximumLengthOfTheVideoCardforfirstcase = 380;
    private const int MaximumLengthOfTheVideoCardforsecondcase = 380;

    private const int MaximumWidthOfTheVideoCardforfirstcase = 165;
    private const int MaximumWidthOfTheVideoCardforsecondcase = 165;

    private const int SupportedMotherboardFormFactorsforfirstcase = 1177;
    private const int SupportedMotherboardFormFactorsforsecondcase = 1177;

    private const int Heightforcase = 1177;
    private const int Widthforcase = 1177;
    private const int Heightforcooling = 10;
    private const int Widthforcooling = 10;

    private const string NameforfirstCPU = "Intel Core i5-12400F OEM";
    private const string NameforsecondCPU = "AMD Ryzen 5 5600X OEM";

    private const bool AvailabilityOfABuiltInVideoCoreforfirstCPU = false;
    private const bool AvailabilityOfABuiltInVideoCoreforsecondCPU = false;

    private const int SupportedMemoryFrequenciesforfirstCPU = 4800;
    private const int SupportedMemoryFrequenciesforsecondCPU = 3200;

    private const int HeatEmissionforfirstCPU = 500;
    private const int HeatEmissionforsecondCPU = 65;

    private const int ConsumptionPowerforfirstCPU = HeatEmissionforfirstCPU;
    private const int ConsumptionPowerforsecondCPU = HeatEmissionforsecondCPU;

    private const int CoreFrequencyforfirstCPU = 3;
    private const int CoreFrequencyforsecondCPU = 4;

    private const int NumberOfCoresforfirstCPU = 6;
    private const int NumberOfCoresforsecondCPU = 8;

    private const int MaximumHeatDissipationforfirstcooling = 180;
    private const int MaximumHeatDissipationforsecondcooling = 50;

    private const string Nameforfirstcooling = "DEEPCOOL GAMMAXX 400 V2 Blue";
    private const string Nameforsecondcooling = "DARK ROCK PRO 4";

    private const string Nameforfirsthdd = "WD Blue";
    private const string Nameforsecondhdd = "WD Purple Surveillance";

    private const int Capacityforfirsthdd = 1024;
    private const int Capacityforsecondhdd = 4096;

    private const int SpindleRotationSpeedforfirsthdd = 7200;
    private const int SpindleRotationSpeedforsecondhdd = 5400;

    private const int PowerConsumptionforfirsthdd = 7;
    private const int PowerConsumptionforsecondhdd = 5;

    private const string Nameforfirstmotherboard = "GIGABYTE B550 AORUS ELITE V2";
    private const string Nameforsecondmotherboard = "MSI MEG X670E GODLIKE";

    private const int NumberOfPCIELanesSolderedOnTheBoardforfirstmotherboard = 3;
    private const int NumberOfPCIELanesSolderedOnTheBoardforsecondmotherboard = 6;

    private const int NumberOfSATAPortsSolderedOnTheBoardforfirstmotherboard = 3;
    private const int NumberOfSATAPortsSolderedOnTheBoardforsecondmotherboard = 6;

    private const int NumberOfTablesUnderRAMforfirstmotherboard = 2;
    private const int NumberOfTablesUnderRAMforsecondmotherboard = 6;

    private const int Versionforfirstbios = 1;
    private const int Versionforsecondbios = 2;

    private const int FirstChipsetstatusforfirstchipsets = 3400;
    private const int SecondChipsetstatusforfirstchipsets = 3466;
    private const int FirstChipsetstatusforsecondchipsets = 4800;
    private const int SecondChipsetstatusforsecondchipsets = 5000;
    private const string NameforfirstPowerSupply = "DEEPCOOL PQ1000M";
    private const string NameforsecondPowerSupply = "AeroCool VX PLUS 500W";

    private const int PeakLoadforfirstpowersupply = 450;
    private const int PeakLoadforsecondpowersupply = 1000;

    private const int PowerConsumptionforfirstram = 2;
    private const int PowerConsumptionforsecondram = 3;

    private const string Nameforfirstram = "Kingston FURY Beast Black";
    private const string Nameforsecondram = "ADATA XPG GAMMIX D20";

    private const int NumberOfAvailableMemorySizeforfirstRAM = 64;
    private const int NumberOfAvailableMemorySizeforsecondRAM = 16;

    private const int SupportedFrequenciesforfirstRAM = 5600;
    private const int SupportedFrequenciesforsecondRAM = 3200;

    private const int Timingsforfirstxmp = 4000;
    private const int Timingsforsecondxmp = 5600;

    private const int Voltageforfirstxmp = 239;
    private const int Voltageforsecondxmp = 241;

    private const int Frequencyforfirstxmp = 1000;
    private const int Frequencyforsecondxmp = 1500;

    private const int Capacityforfirstssd = 512;
    private const int Capacityforsecondssd = 1024;

    private const int MaximumOperatingSpeedforfirstssd = 500;
    private const int MaximumOperatingSpeedforsecondssd = 560;

    private const int PowerConsumptionforfirstssd = 1;
    private const int PowerConsumptionforsecondssd = 3;

    private const string Nameforfirstssd = "Kingston A400";
    private const string Nameforsecondssd = "Samsung 870 EVO";

    private const int VideoCardHeightforfirstcard = 294;
    private const int VideoCardHeightforsecondcard = 322;

    private const int VideoCardWidthforfirstcard = 118;
    private const int VideoCardWidthforsecondcard = 136;

    private const int AmountOfVideoMemoryforfirstcard = 8;
    private const int AmountOfVideoMemoryforsecondcard = 24;

    private const int PCIEVersionforfirstcard = 16;
    private const int PCIEVersionforsecondcard = 20;

    private const int ChipFrequencyforfirstcard = 600;
    private const int ChipFrequencyforsecondcard = 1000;

    private const int PowerConsumptionforfirstcard = 225;
    private const int PowerConsumptionforsecondcard = 450;

    private const string Nameforfirstcard = "GeForce RTX 3060 Ti Dual";
    private const string Nameforsecondcard = "MSI GeForce RTX 4090 VENTUS 3X OC";

    private static readonly IConnectionOption ConnectionOptioforfirstssd = new SATA();
    private static readonly IConnectionOption ConnectionOptioforsecondssd = new SATA();

    private static readonly XMP Firsstxmp = new XMP(Timingsforfirstxmp, Voltageforfirstxmp, Frequencyforfirstxmp);
    private static readonly XMP Secondxmp = new XMP(Timingsforsecondxmp, Voltageforsecondxmp, Frequencyforsecondxmp);

    private static readonly IFormFactor FormFactorforfirstmothermoard = new StandardATX();
    private static readonly IFormFactor FormFactorforsecondmothermoard = new EATX();

    private static readonly IFormFactor FormFactorforfirstram = new DIMM();
    private static readonly IFormFactor FormFactorforsecondram = new DIMM();

    private static readonly IMemoryStandard ConnectionOptioforfirstram = new DDR4();
    private static readonly IMemoryStandard ConnectionOptioforsecondram = new DDR4();

    private static readonly IList<ICPU> Chipsetforfirstbios = new List<ICPU>()
    {
        new IntelCorei512400FOEM(),
        new AMDRyzen55600XOEM(),
    };
    private static readonly IList<ICPU> Chipsetforsecondbios = new List<ICPU>()
    {
        new AMDRyzen55600XOEM(),
    };

    private static readonly Bios Biosforfirstmothermotherboard = new Bios(Versionforfirstbios, Chipsetforfirstbios);
    private static readonly Bios Biosforsecondmothermotherboard = new Bios(Versionforsecondbios, Chipsetforsecondbios);

    private static readonly IList<int> Chipsetforfirstmotherboard = new List<int>()
    {
        FirstChipsetstatusforfirstchipsets,
        SecondChipsetstatusforfirstchipsets,
    };
    private static readonly IList<int> Chipsetforsecondmotherboard = new List<int>()
    {
        FirstChipsetstatusforsecondchipsets,
        SecondChipsetstatusforsecondchipsets,
    };

    private static readonly IMemoryStandard MemoryStandardforfirstmotherboard = new DDR4();
    private static readonly IMemoryStandard MemoryStandardforsecondmotherboard = new DDR5();

    private static readonly ISocket CPUSocketforfirstmotherboard = new AM4();
    private static readonly ISocket CPUSocketforsecondmotherboard = new LGA1700();

    private static readonly IList<ISocket> SocketsforfirstCooling = new List<ISocket>
    {
        new LGA1700(),
    };
    private static readonly IList<ISocket> SocketsforsecondCooling = new List<ISocket>
    {
        new AM4(),
    };

    private static Dimensions dimensionsforfirstcase = new Dimensions(Heightforcase, Widthforcase);
    private static Dimensions dimensionsforsecondcooling = new Dimensions(Heightforcooling, Widthforcooling);

    private static TableOfVideoCardCharacteristics _firstcard = new TableOfVideoCardCharacteristics(
        VideoCardHeightforfirstcard,
        VideoCardWidthforfirstcard,
        AmountOfVideoMemoryforfirstcard,
        PCIEVersionforfirstcard,
        ChipFrequencyforfirstcard,
        PowerConsumptionforfirstcard,
        Nameforfirstcard);

    private static TableOfVideoCardCharacteristics _secondcard = new TableOfVideoCardCharacteristics(
        VideoCardHeightforsecondcard,
        VideoCardWidthforsecondcard,
        AmountOfVideoMemoryforsecondcard,
        PCIEVersionforsecondcard,
        ChipFrequencyforsecondcard,
        PowerConsumptionforsecondcard,
        Nameforsecondcard);

    private static TableOfSSDDriveCharacteristics _firstssd = new TableOfSSDDriveCharacteristics(
        Nameforfirstssd,
        ConnectionOptioforfirstssd,
        Capacityforfirstssd,
        MaximumOperatingSpeedforfirstssd,
        PowerConsumptionforfirstssd);

    private static TableOfSSDDriveCharacteristics _secondssd = new TableOfSSDDriveCharacteristics(
        Nameforsecondssd,
        ConnectionOptioforsecondssd,
        Capacityforsecondssd,
        MaximumOperatingSpeedforsecondssd,
        PowerConsumptionforsecondssd);

    private static TableOfRAMCharacteristics _firstram = new TableOfRAMCharacteristics(
        NumberOfAvailableMemorySizeforfirstRAM,
        SupportedFrequenciesforfirstRAM,
        Firsstxmp,
        FormFactorforfirstram,
        ConnectionOptioforfirstram,
        PowerConsumptionforfirstram,
        Nameforfirstram);

    private static TableOfRAMCharacteristics _secondram = new TableOfRAMCharacteristics(
        NumberOfAvailableMemorySizeforsecondRAM,
        SupportedFrequenciesforsecondRAM,
        Secondxmp,
        FormFactorforsecondram,
        ConnectionOptioforsecondram,
        PowerConsumptionforsecondram,
        Nameforsecondram);

    private static TableOfPowerSupplyCharacteristics _firstpowersupply = new TableOfPowerSupplyCharacteristics(
        NameforfirstPowerSupply,
        PeakLoadforfirstpowersupply);

    private static TableOfPowerSupplyCharacteristics _secondpowersupply = new TableOfPowerSupplyCharacteristics(
        NameforsecondPowerSupply,
        PeakLoadforsecondpowersupply);

    private static TableOfMotherboardCharacteristics _firstmotherboard = new TableOfMotherboardCharacteristics(
        Nameforfirstmotherboard,
        CPUSocketforfirstmotherboard,
        NumberOfPCIELanesSolderedOnTheBoardforfirstmotherboard,
        NumberOfSATAPortsSolderedOnTheBoardforfirstmotherboard,
        Chipsetforfirstmotherboard,
        MemoryStandardforfirstmotherboard,
        NumberOfTablesUnderRAMforfirstmotherboard,
        FormFactorforfirstmothermoard,
        Biosforfirstmothermotherboard);

    private static TableOfMotherboardCharacteristics _secondmotherboard = new TableOfMotherboardCharacteristics(
        Nameforsecondmotherboard,
        CPUSocketforsecondmotherboard,
        NumberOfPCIELanesSolderedOnTheBoardforsecondmotherboard,
        NumberOfSATAPortsSolderedOnTheBoardforsecondmotherboard,
        Chipsetforsecondmotherboard,
        MemoryStandardforsecondmotherboard,
        NumberOfTablesUnderRAMforsecondmotherboard,
        FormFactorforsecondmothermoard,
        Biosforsecondmothermotherboard);

    private static TableOfHardDriveCharacteristics _firsthdd = new TableOfHardDriveCharacteristics(
        Nameforfirsthdd,
        Capacityforfirsthdd,
        SpindleRotationSpeedforfirsthdd,
        PowerConsumptionforfirsthdd);

    private static TableOfHardDriveCharacteristics _secondhdd = new TableOfHardDriveCharacteristics(
        Nameforsecondhdd,
        Capacityforsecondhdd,
        SpindleRotationSpeedforsecondhdd,
        PowerConsumptionforsecondhdd);

    private static TableOfCPUCoolingSystemCharacteristics _firstcooling = new TableOfCPUCoolingSystemCharacteristics(
        dimensionsforsecondcooling,
        SocketsforfirstCooling,
        MaximumHeatDissipationforfirstcooling,
        Nameforfirstcooling);

    private static TableOfCPUCoolingSystemCharacteristics _secondcooling = new TableOfCPUCoolingSystemCharacteristics(
        dimensionsforsecondcooling,
        SocketsforsecondCooling,
        MaximumHeatDissipationforsecondcooling,
        Nameforsecondcooling);

    private static TableOfCPUCharacteristics _firstcpu = new TableOfCPUCharacteristics(
        NameforfirstCPU,
        AvailabilityOfABuiltInVideoCoreforfirstCPU,
        SupportedMemoryFrequenciesforfirstCPU,
        HeatEmissionforfirstCPU,
        ConsumptionPowerforfirstCPU,
        CoreFrequencyforfirstCPU,
        NumberOfCoresforfirstCPU,
        new LGA1700());

    private static TableOfCPUCharacteristics _secondcpu = new TableOfCPUCharacteristics(
        NameforsecondCPU,
        AvailabilityOfABuiltInVideoCoreforsecondCPU,
        SupportedMemoryFrequenciesforsecondCPU,
        HeatEmissionforsecondCPU,
        ConsumptionPowerforsecondCPU,
        CoreFrequencyforsecondCPU,
        NumberOfCoresforsecondCPU,
        new AM4());

    private static TableOfCaseCharacteristics _firstcase = new TableOfCaseCharacteristics(
        Nameoffirstcorpus,
        MaximumLengthOfTheVideoCardforfirstcase,
        MaximumWidthOfTheVideoCardforfirstcase,
        SupportedMotherboardFormFactorsforfirstcase,
        dimensionsforfirstcase,
        MaximumCPUCoolerHeightforfirstcase);

    private static TableOfCaseCharacteristics _secondcase = new TableOfCaseCharacteristics(
        Nameofsecondcorpus,
        MaximumLengthOfTheVideoCardforsecondcase,
        MaximumWidthOfTheVideoCardforsecondcase,
        SupportedMotherboardFormFactorsforsecondcase,
        dimensionsforsecondcooling,
        MaximumCPUCoolerHeightforsecondcase);

    public static void GetData(Database database)
    {
        database.Addtable(FirstID, _firstcard);
        database.Addtable(SecondID, _secondcard);
        database.Addtable(ThirdID, _firstssd);
        database.Addtable(FourthID, _secondssd);
        database.Addtable(FifthID, _firstram);
        database.Addtable(SixthID, _secondram);
        database.Addtable(SeventhID, _firstpowersupply);
        database.Addtable(EighthID, _secondpowersupply);
        database.Addtable(NinthID, _firstmotherboard);
        database.Addtable(TenthID, _secondmotherboard);
        database.Addtable(EleventhID, _firsthdd);
        database.Addtable(TwelfthID, _secondhdd);
        database.Addtable(ThirteenthID, _firstcooling);
        database.Addtable(FourteenthID, _secondcooling);
        database.Addtable(FifteenthID, _firstcpu);
        database.Addtable(SixteenthID, _secondcpu);
        database.Addtable(SeventeenthID, _firstcase);
        database.Addtable(EighteenthID, _secondcase);
    }
}