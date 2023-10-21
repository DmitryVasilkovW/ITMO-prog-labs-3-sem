using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models.Videocard.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Services;

public interface IWithVideoCard
{
    IWithPowerSupply WithVideoCard(VideoCard videoCard);
}