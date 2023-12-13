using LabWork5.Application.Models.Admins;

namespace LabWork5.Application.Abstractions;

public interface IAdminRepository
{
    Admin? FindAdminByUsername(string adminname);
}