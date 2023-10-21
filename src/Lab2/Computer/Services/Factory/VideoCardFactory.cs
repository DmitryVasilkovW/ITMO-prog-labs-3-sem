using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Databases;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services.Factory;

public class VideoCardFactory : IPartFactory<VideoCard, TableOfVideoCardCharacteristics>
{
    public VideoCard CreatePart(TableOfVideoCardCharacteristics characteristics)
    {
        return new VideoCard(
            characteristics.VideoCardHeight,
            characteristics.VideoCardWidth,
            characteristics.AmountOfVideoMemory,
            characteristics.PCIEVersion,
            characteristics.ChipFrequency,
            characteristics.PowerConsumption,
            characteristics.Name);
    }
}