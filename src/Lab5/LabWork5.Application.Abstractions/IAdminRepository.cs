namespace LabWork5.Application.Abstractions;

public interface IAdminRepository
{
    public bool PasswordVerification(string inputpassword);
}